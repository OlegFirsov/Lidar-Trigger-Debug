using System;
using System.IO;
using System.Collections;
using Microsoft.SPOT;
using FastloadMedia.NETMF.Http;


namespace NeonMika.Webserver.Responses.ComplexResponses
{
    public class SaveSystemNetworkSettings: NeonMika.Webserver.Responses.JSONResponse
    {
        private SaveSystemNetworkSettingsResponse _saveSystemNetworkSettingsResponse;
        public SaveSystemNetworkSettings(string indexPage)
            : base(indexPage, (JSONResponseMethodObject)null)
        {
            _saveSystemNetworkSettingsResponse = new SaveSystemNetworkSettingsResponse();
            setResponseMethodObject(_saveSystemNetworkSettingsResponse.SaveJsonFile);
        }
         
        /*public override bool ConditionsCheckAndDataFill(Request e)
        {
            if (e.URL == "savesystemnetworksettings")
                return true;
            else
                return false;
        }*/
        class  SaveSystemNetworkSettingsResponse
        {

        public void SaveJsonFile(Request e, JsonObject result)
        {
            string filePath = "\\SD\\config.json";
            string line;
            int pos;
            string fileTmp = "\\SD\\tmp.json";            
            Hashtable reqOnSave = e.GetArguments;
            if (!File.Exists(filePath))
            {               
                using (var fl = File.Create(filePath))
                {
                    using (StreamWriter jsonFile = new StreamWriter(fl))
                    {                       
                        jsonFile.WriteLine("{");
                        int countSettings = reqOnSave.Count;
                        foreach (DictionaryEntry entry in reqOnSave)
                        {                     
                            if (countSettings > 1)
                                jsonFile.WriteLine("\"" + entry.Key + "\"" + ":" + "\"" + entry.Value + "\",");
                            else
                                jsonFile.WriteLine("\"" + entry.Key + "\"" + ":" + "\"" + entry.Value + "\"");
                            countSettings--;
                        }
                        jsonFile.WriteLine("}");
                    }
                }
            }
            else
            {                
                using (var fileReadWrite = File.Open(filePath,FileMode.Open,FileAccess.ReadWrite,FileShare.None))               
                { 
                    using(StreamReader reader = new StreamReader(fileReadWrite))
                    using (StreamWriter writer = new StreamWriter(fileTmp))
                    {
                        int countSettings = reqOnSave.Count;
                        writer.WriteLine("{");
                        while (null != (line = reader.ReadLine()))
                        {                          
                            string newline;
                            foreach (DictionaryEntry entry in reqOnSave) 
                            {                                
                                pos = line.IndexOf(entry.Key.ToString());
                                if (pos >= 0)
                                    {
                                        if (countSettings > 1)
                                            newline = line.Substring(0, pos + entry.Key.ToString().Length) + "\":\"" + entry.Value.ToString() + "\",";
                                        else
                                            newline = line.Substring(0, pos + entry.Key.ToString().Length) + "\":\"" + entry.Value.ToString() + "\"";
                                        writer.WriteLine(newline);
                                        countSettings--;   
                                    }                              
                            }
                        }
                        writer.WriteLine("}");
                    }
                }
            }
            if(File.Exists(filePath)) File.Delete(filePath);
            if (File.Exists(fileTmp)) File.Move(fileTmp,filePath);
        }


        }
    }
}
