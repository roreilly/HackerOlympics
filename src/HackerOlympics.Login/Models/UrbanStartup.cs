using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace HackerOlympics.Login.Models
{
    public class UrbanStartup
    {
        public string StartupName { get; set; }
        public Dictionary<string, string> Names { get; set; }


        public string GetNameFromUrbanDictionary(out string meaning)
        {
            var request = WebRequest.Create("http://www.urbandictionary.com/random.php");
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "Codehouse.ServiceConsole.Shell v1.0.0.0";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // get the title
            int titleStart = responseFromServer.IndexOf("<title>");
            titleStart = titleStart + "<title>".Length;
            int titleEnd = responseFromServer.IndexOf("</title>");
            string title = responseFromServer.Substring(titleStart, titleEnd - titleStart).Replace("Urban Dictionary: ", "");

            titleStart = responseFromServer.IndexOf("<div class='meaning'>");
            titleStart = titleStart + "<div class='meaning'>".Length;
            titleEnd = responseFromServer.IndexOf("</div>", titleStart);
            meaning = responseFromServer.Substring(titleStart, titleEnd - titleStart);

            // Clean up the streams and the response.
            reader.Close();
            response.Close();
            return title;
        }

        private const int NameWords = 3;

        public string GetRandomName()
        {
            Names = new Dictionary<string, string>();
            StartupName = "";
            for (int i = 0; i < 3; i++)
            {
                string meaning;
                string name = GetNameFromUrbanDictionary(out meaning);
                StartupName += name + " ";
                Names[name] = meaning;
            }
            StartupName = StartupName.Trim();
            return StartupName;
        }

    }
}