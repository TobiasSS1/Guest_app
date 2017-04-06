using Guest_app.Common;
using Guest_app.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Guest_app.Persistency
{
   public class PersistencyService
    {
        const string serverurl = "http://gaestwebapi.azurewebsites.net";

        public static void SaveGuestAsJsonAsync(Guest GuestToSave)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient Client = new HttpClient();
            handler.UseDefaultCredentials = true;

            
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverurl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var responce = client.PostAsJsonAsync<Guest>("Api/Guests", GuestToSave).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static ObservableCollection<Guest> LoadGuestsFromJsonAsync()
        {
            HttpClient Client = new HttpClient();
            ObservableCollection<Guest> Temp_list = new ObservableCollection<Guest>();

            using (var client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Clear();
                Client.BaseAddress = new Uri(serverurl);
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage responce = Client.GetAsync("Api/Guests").Result;

                    if (responce.IsSuccessStatusCode)
                    {
                        Temp_list = responce.Content.ReadAsAsync<ObservableCollection<Guest>>().Result;
                    }
                }
                catch (Exception)
                {
                    Temp_list = null;
                }

                return Temp_list;
            }
        }

        public static ObservableCollection<GuestBookings> LoadGuestsBookingsFromJsonAsync()
        {
            HttpClient Client = new HttpClient();

            ObservableCollection<GuestBookings> Temp_list = new ObservableCollection<GuestBookings>();

            using (var client = new HttpClient())
            {
                Client.DefaultRequestHeaders.Clear();
                Client.BaseAddress = new Uri(serverurl);
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage responce = Client.GetAsync("Api/GuestBookings").Result;

                    if (responce.IsSuccessStatusCode)
                    {
                        Temp_list = responce.Content.ReadAsAsync<ObservableCollection<GuestBookings>>().Result;

                    }
                }
                catch (Exception)
                {
                    Temp_list = null;
                }

                return Temp_list; //= list as ObservableCollection<GuestBookings>;
            }
        }

        public static void DeleteGuest(Guest GuestToDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverurl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var responce = client.DeleteAsync("Api/Guests/" + GuestToDelete.Guest_No).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static void UpdateSelectedGuest(Guest GuestToUpdate)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient Client = new HttpClient();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverurl);
                client.DefaultRequestHeaders.Clear();
                try
                {
                    var responce = client.PutAsJsonAsync<Guest>("Api/Guests/" + GuestToUpdate.Guest_No, GuestToUpdate).Result;
                    HelperClass.msg("Gæstens data er opdateret");
                }
                catch (Exception)
                {
                    HelperClass.msg("Der er sket en fejl");
                    throw;
                }
            }
        }
    }
}
