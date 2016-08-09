using System;
using System.Text;
using System.IO;
using System.Collections;
using Microsoft.SPOT;
using NeonMika.Webserver;
using FastloadMedia.NETMF.Http;

namespace NeonMika.Webserver.Responses.ComplexResponses
{
    class ShowSystemNetworkSettings : NeonMika.Webserver.Responses.JSONResponse
    {
        private ShowSystemNetworkSettingsResponse _showSystemNetworkSettingsResponse;
        public ShowSystemNetworkSettings(string indexPage)
            : base(indexPage, (JSONResponseMethodObject) null)

        {
            _showSystemNetworkSettingsResponse = new ShowSystemNetworkSettingsResponse();
            setResponseMethodObject(_showSystemNetworkSettingsResponse.showJson);
        }
    }
    class ShowSystemNetworkSettingsResponse
    {
        public ShowSystemNetworkSettingsResponse()
        {
            // constructor
        }
        public void showJson(Request e, JsonObject results)
        {
            string fileName = "\\SD\\config.json";
            using(var stream = File.OpenRead(fileName))
            {
                using (var reader = new StreamReader(stream))
                {

                    results.Add("username", "");
                    results.Add("password", "");
                    results.Add("dhcp", "");
                    results.Add("static-ip", "");
                    results.Add("network-mask", "");
                    results.Add("gateway", "");
                    results.Add("ntp", "");
                    results.Add("timeoffset", "");
                }
            }
        }
    }
}
