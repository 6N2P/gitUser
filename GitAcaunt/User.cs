using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitAcaunt
{
    public class User
    {
        public string Name { get; set; }   
        public string Account { get; set; }
        public string Maill { get; set; }
        public User() { }
        public User(string name,string account ,string maill)
        {
            Name = name;
            Account = account;
            Maill = maill;
        }
    }
}
