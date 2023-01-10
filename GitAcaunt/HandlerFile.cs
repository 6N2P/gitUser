using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GitAcaunt
{
    class HandlerFile
    {
        static string path = @"..\..\..\ac.umn";

        public static string[] GetUsers ()
        {

            string userString = File.ReadAllText(path);
            userString = Regex.Replace(userString, "\r", "");
            userString = Regex.Replace(userString, "\n", "");
            userString = Regex.Replace(userString, "\t", "");
            
            string[] users = userString.Split('#');
            return users;
        }
        
    }

    
}
