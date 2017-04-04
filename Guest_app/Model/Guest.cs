using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_app.Model
{
    public class Guest
    {
        public int Guest_No { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public Guest(int id, string name, string address)
        {
            this.Guest_No = id;
            this.name = name;
            this.address = address;
        }

        public override string ToString()
        {
            return "ID: "+ this.Guest_No + "Navn: "+ this.name + "addresse: " + this.address;
        }
    }
}
