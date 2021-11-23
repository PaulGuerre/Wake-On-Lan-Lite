using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Wake_On_Lan_Lite
{

    //Class that retrieves the mac addresses from the mac.json file
    class fileControl
    {

        private const string PATH = @"C:\Program Files (x86)\Wake On Lan Lite";
        private const string PATHFILE = @"C:\Program Files (x86)\Wake On Lan Lite\mac_address.json";

        //Function that creates the folder and the file if they don't exist
        public void createFileIfNotExist()
        {
            if (Directory.Exists(PATH))
            {
                if (!File.Exists(PATHFILE))
                {
                    File.Create(PATHFILE);
                }
            }
            else
            {
                Directory.CreateDirectory(PATH);
                File.Create(PATHFILE);
            }
        }

        //Function that add a new device in the json file
        public void addAddress(Device device)
        {
            List<Device> devices = getAllAddresses();
            devices.Add(device);

            List<string> name = new List<string>();
            List<string> address = new List<string>();

            foreach(Device d in devices)
            {
                name.Add(d.NAME);
                address.Add(d.ADDRESS); ;
            }

            var objects = new { name, address };          

            File.WriteAllText(PATHFILE, JsonConvert.SerializeObject(objects));
        }

        void deleteAddress()
        {

        }

        //Function that return the list of all the devices stocked in the json file
        public List<Device> getAllAddresses()
        {
            List<Device> devices = new List<Device>();
            JObject data = JObject.Parse(File.ReadAllText(PATHFILE));
            List<string> name = data["name"].Select(t => (string)t).ToList();
            List<string> address = data["address"].Select(t => (string)t).ToList();
            for(int i = 0; i < name.Count; i ++)
            {
                devices.Add(new Device() { NAME = name[i], ADDRESS = address[i] });
            }

            return devices;
        }
    }
}
