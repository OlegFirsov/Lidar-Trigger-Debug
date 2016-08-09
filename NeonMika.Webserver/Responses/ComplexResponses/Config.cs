using System;
using Microsoft.SPOT;
using System.Text;
using NeonMika.Webserver;

namespace NeonMika.Webserver.Responses.ComplexResponses
{
    public class Config : NeonMika.Webserver.Responses.Response
    {
         public Config(string indexPage)
            : base(indexPage)
         {}

         public override bool ConditionsCheckAndDataFill(Request e)
         {
             if (e.URL == "config")
                 return true;
             else
                 return false;
         }
        public override bool SendResponse(Request e)
        {    
                 //const string pathToConfig = @"http://192.168.2.185/SD/fileslist.html";
                 string pathToConfig = @"SD/mainpage.html";
                 string index = "<html><head><script>window.location=" + "\"" + pathToConfig + "\"" + "</script>" + 
                     "</head><body></body></html>";
                 SendData(e.Client, Encoding.UTF8.GetBytes(index));
                 return true;
             }        
    }
}
