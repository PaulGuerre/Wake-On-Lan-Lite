using System.IO;

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

        void addAddress()
        {
            
        }

        void deleteAddress()
        {

        }

        void getAllAddresses()
        {
            /*JObject o1 = JObject.Parse(File.ReadAllText(PATHFILE));

            // read JSON directly from a file
            using (StreamReader file = File.OpenText(PATHFILE))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
            }

            return o1.ToString();*/
        }
    }
}
