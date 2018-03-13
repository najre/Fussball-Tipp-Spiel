using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FussballTippsspielWPF
{
    class Json
    {
        public string JsonRunterladen(string woche)
        {
            string path2 = @"C:\Users\jan\Documents\Bundesliga_Ergebnisse\" + woche + ".json";
            string path = "https://www.openligadb.de/api/getmatchdata/bl1/2017/" + woche;
            if (!File.Exists(path2))
            {
                using (FileStream fs = File.Create(path2))
                {
                    fs.Close();
                }
                WebClient Client = new WebClient();
                Client.DownloadFile(path, @"C:\Users\jan\Documents\Bundesliga_Ergebnisse\" + woche + ".json");
                string jsonString = GetJsonToString(path2, woche);
                WriteJson(jsonString, woche);
                
            }
            string readJson = ReadJson(woche);

            return readJson;
        }



        private string GetJsonToString(string path, string woche)
        {
            string jsonString = "";

            System.IO.StreamReader streamReader = new StreamReader(@"C:\Users\jan\Documents\Bundesliga_Ergebnisse\" + woche + ".json");

            jsonString = streamReader.ReadToEnd();
            streamReader.Close();
            return jsonString;
        }

        private string ReadJson(string woche)
        {
            string st = File.ReadAllText(@"C:\Users\jan\Documents\Bundesliga_Ergebnisse\" + woche + ".json");
            return st;

        }
        private void WriteJson(string jsonString, string woche)
        {
            
            System.IO.StreamWriter streamWriter = new StreamWriter(@"C:\Users\jan\Documents\Bundesliga_Ergebnisse\" + woche + ".json");
            streamWriter.Write(jsonString);
            streamWriter.Close();
        }
        
    }
}
