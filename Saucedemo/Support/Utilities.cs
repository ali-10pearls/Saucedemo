using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Saucedemo.Page;
using TechTalk.SpecFlow;
using System.IO;


namespace Saucedemo.Support
{
    public class Utilities
    {
        private static JObject appConfig;

        static Utilities()
        {
            LoadAppConfig();
        }

        public static void LoadAppConfig()
        {
            try
            {
                //string json = File.ReadAllText("C:\\Users\\shaikh.umair\\source\\Repos\\SpecFlow_DEMO.Specs\\Support\\applicationData.json");
                //appConfig = JObject.Parse(json);

                //need to test it and check it here!!!

                string file = AppDomain.CurrentDomain.BaseDirectory + "\\" + "applicationData.json";
                string json = File.ReadAllText(file);
                appConfig = JObject.Parse(json);

                /*  string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Support");
                  string filePath = Path.Combine(folderPath, "applicationData.json");

                  string json = File.ReadAllText(filePath);
                  JObject appConfig = JObject.Parse(json);*/

                /*string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Support", "applicationData.json");
                string json = File.ReadAllText(filePath);
                JObject appConfig = JObject.Parse(json);
*/
                /*
                                string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "Support", "applicationData.json");
                                string json = File.ReadAllText(filePath);
                                JObject appConfig = JObject.Parse(json);*/

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading applicationData.json: " + ex.Message);
                appConfig = null;
            }
        }

        public static string GetValue(string key)
        {
            if (appConfig == null)
            {
                Console.WriteLine("App config not loaded.");
                return null;
            }

            return appConfig[key]?.ToString();
        }
    }
}
