using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Wake_On_Lan_Lite
{

    //Class that retrieves the mac addresses from the mac.json file
    class fileControl
    {

        private const string PATH = @"C:\Program Files (x86)\Wake On Lan Lite";
        private const string PATHFILE = @"C:\Program Files (x86)\Wake On Lan Lite\mac_address.json";

        void addAddress()
        {

        }

        void deleteAddress()
        {

        }

        public string getAllAddresses()
        {
            JObject o1 = JObject.Parse(File.ReadAllText(PATHFILE));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(PATHFILE))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }

            return o1.ToString();
        }
    }
}
