using Guest_app.Model;
using Guest_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guest_app.Persistency;

namespace Guest_app.Handler
{
    class GuestHandler
    {
        public GuestViewModel guestViewModel { get; set; }

        public GuestHandler(GuestViewModel evm)
        {
            this.guestViewModel = evm;
        }

        public void CreateGuest()
        {
            Guest temp_guest = new Guest(guestViewModel.Id, guestViewModel.Name, guestViewModel.Address);

            GuestSingleton.Instance.AddGuest(temp_guest);
        }

        public void DeleteGuest()
        {
            GuestSingleton.Instance.RemoveGuest(guestViewModel.SelectedGuest);
            PersistencyService.DeleteGuest(guestViewModel.SelectedGuest);
        }
    }
}
