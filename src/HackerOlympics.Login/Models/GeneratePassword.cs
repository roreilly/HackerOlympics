using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HackerOlympics.Login.Models
{
    public class GeneratePassword
    {
        public GeneratePassword()
        {
            Names = new Dictionary<string, string>();
            Names["Rob"] = "+447867797945";
            Names["Jack"] = "+447472666004";
            Names["James"] = "+447432572961";
            Names["Kevin"] = "+447593093761";
            
        }
        public Dictionary<string, string> Names { get; set; }

        static GeneratePassword()
        {
            
            TelephoneList = new Dictionary<string, string>();
        }

        private static string LastPerson { get; set; }

        public static Dictionary<string, string> TelephoneList { get; set; }

        public void GeneratePass(string forName)
        {
            Random r = new Random();
            string password = "";
            for (int i = 0; i < 4; i++)
            {
                string name = Names.Keys.ElementAt(r.Next(Names.Count));
                
                password += name + " ";
            }
            password = password.Trim();
            TelephoneList[forName] = password;
            // SMS it
            var twilio = new Twilio.TwilioRestClient("ACa23f5b1a623ffbaa2958a7f91b985f03", "74bf07d264faa42d49bcc316e20e4895");
            var tMessage = twilio.SendMessage("+441502797245", Names[forName], password);
            LastPerson = forName;
        }

        public bool Login(bool useLastLogin, string password)
        {
            if (TelephoneList.ContainsKey(LastPerson) && TelephoneList[LastPerson] == password)
            {
                Authenticated = true;
            }
            else
            {
                Authenticated = false;
            }
            return Authenticated;
        }

        public bool Authenticated { get; set; }
    }
}