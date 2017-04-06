using Guest_app.Model;
using Guest_app.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guest_app.Persistency;
using Windows.UI.Popups;
using Guest_app.Common;

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
            if (guestViewModel.Id != 0 && guestViewModel.Name != null && guestViewModel.Address != null)
            {
                Guest temp_guest = new Guest(guestViewModel.Id, guestViewModel.Name, guestViewModel.Address);
                GuestSingleton.Instance.AddGuest(temp_guest);
            }
            else
            {
                HelperClass.msg("Et felt er ikke udfyldt");
            }
        }

        public void DeleteGuest()
        {
            GuestSingleton.Instance.RemoveGuest(guestViewModel.SelectedGuest);
        }

        public void UpdateGuest()
        {
            Guest updatedGuest = guestViewModel.SelectedGuest;
            PersistencyService.UpdateSelectedGuest(updatedGuest);
            PersistencyService.LoadGuestsFromJsonAsync();

        }
    }
}
