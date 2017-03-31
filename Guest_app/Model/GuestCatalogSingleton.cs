using Guest_app.Persistency;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guest_app.Model
{
    class GuestSingleton
    {
        private static readonly GuestSingleton instance = new GuestSingleton();

        public static GuestSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Guest> GuestCollection { get; set; }

        private GuestSingleton()
        {
            GuestCollection = new ObservableCollection<Guest>();
            LoadJson();
        }

        public void AddGuest(Guest GuestTilAdd)
        {
            GuestCollection.Add(GuestTilAdd);
            PersistencyService.SaveGuestAsJsonAsync(GuestTilAdd);
        }

        public void RemoveGuest(Guest GuestTilRemove)
        {
            if (GuestTilRemove != null)
            {
                GuestCollection.Remove(GuestTilRemove);
            }
        }

        private void LoadJson()
        {
            try
            {
                GuestCollection = PersistencyService.LoadGuestsFromJsonAsync();
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e);
            }
        }
    }
}
