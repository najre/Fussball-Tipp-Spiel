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
    public static class Globals
    {
        public static string ordnerPath = @"C:\Users\jan52\source\repos\Fussball-Tipp-Spiel\Bundesliga_Daten\";
    }
    
    class Json
    {
        public string JsonRunterladen(string woche)
        {
            Globals.ordnerPath += woche + ".json";
            string path = "https://www.openligadb.de/api/getmatchdata/bl1/2017/" + woche;
            if (!File.Exists(Globals.ordnerPath))
            {
                using (FileStream fs = File.Create(Globals.ordnerPath))
                {
                    fs.Close();
                }
                WebClient Client = new WebClient();
                Client.DownloadFile(path, Globals.ordnerPath);
                string jsonString = GetJsonToString(path: Globals.ordnerPath, woche: woche);
                JToken parsedJson = JToken.Parse(jsonString);
                var beautifiedJson = parsedJson.ToString(Newtonsoft.Json.Formatting.Indented);
                WriteJson(beautifiedJson, woche);
                
            }
            string readJson = ReadJson(woche);

            return readJson;
        }



        private string GetJsonToString(string path, string woche)
        {
            string jsonString = "";

            System.IO.StreamReader streamReader = new StreamReader(Globals.ordnerPath);

            jsonString = streamReader.ReadToEnd();
            streamReader.Close();
            return jsonString;
        }

        private string ReadJson(string woche)
        {
            string st = File.ReadAllText(Globals.ordnerPath);
            return st;

        }
        private void WriteJson(string jsonString, string woche)
        {
            
            System.IO.StreamWriter streamWriter = new StreamWriter(Globals.ordnerPath);
            streamWriter.Write(jsonString);
            streamWriter.Close();
        }
        
    }
}
