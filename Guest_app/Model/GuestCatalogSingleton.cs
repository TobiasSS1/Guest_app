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
        #region properties
        private static readonly GuestSingleton instance = new GuestSingleton();

        public static GuestSingleton Instance
        {
            get { return instance; }
        }

        public ObservableCollection<Guest> GuestCollection { get; set; }

        public ObservableCollection<GuestBookings> Temp_list { get; set; }

        public delegate void JsonLoad();
        
        #endregion

        private GuestSingleton()
        {
            GuestCollection = new ObservableCollection<Guest>();
            GuestCollection.Clear();

            JsonLoad fetch_data = LoadGuestCollectionJson;
            fetch_data += LoadGuestBookings;
            fetch_data.Invoke();
        }

        #region Methods
        public void AddGuest(Guest GuestTilAdd)
        {
            if (GuestTilAdd.Guest_No != 0 && GuestTilAdd.name != "" && GuestTilAdd.address != "")
            {
                GuestCollection.Add(GuestTilAdd);
                PersistencyService.SaveGuestAsJsonAsync(GuestTilAdd);
            }            
        }

        public void RemoveGuest(Guest GuestTilRemove)
        {
            if (GuestTilRemove != null)
            {
                GuestCollection.Remove(GuestTilRemove);
                PersistencyService.DeleteGuest(GuestTilRemove);
            }
        }

        public void UpdateGuest(Guest SelectedGuest)
        {
            if (SelectedGuest != null)
            {
                PersistencyService.UpdateSelectedGuest(SelectedGuest);
            }
        }

        public void LoadGuestCollectionJson()
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

        public void LoadGuestBookings()
        {
            try
            {
                Temp_list = PersistencyService.LoadGuestsBookingsFromJsonAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
