using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_app.Model
{
    public class GuestBookings
    {
        public string Name { get; set; }
        public int? BOOKINGS { get; set; }

        public override string ToString()
        {
            return "Navn: " + Name + " Bookinger: " + BOOKINGS;
        }
    }
}
