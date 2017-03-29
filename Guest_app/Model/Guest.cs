using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_app.Model
{
    public class Guest
    {
        public int _id { get; set; }

        public string _name { get; set; }

        public string _address { get; set; }

        public Guest(int id, string name, string address)
        {
            this._id = id;
            this._name = name;
            this._address = address;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
