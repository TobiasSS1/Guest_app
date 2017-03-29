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
    class PersistencyService
    {

        const string serverurl = "http://Guestmakerwebapi.azurewebsites.net";

        /// <summary>
        /// Saves an Guest to the Db.
        /// </summary>
        /// <param name="GuestToSave"></param>
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
                    //Todo Fix the insert, it returns HTTP:500 (Internal Server Error).
                    var responce = client.PostAsJsonAsync<Guest>("Api/Guests", GuestToSave).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Returns a Observerble Collection of Guests from the Db.
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Guest> LoadGuestsFromJsonAsync()
        {
            //vi kalder Clienthandler
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient Client = new HttpClient();
            handler.UseDefaultCredentials = true;

            ObservableCollection<Guest> Temp_list = new ObservableCollection<Guest>();

            using (var client = new HttpClient(handler))
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


        /// <summary>
        /// Deletes the select guest form the db.
        /// </summary>
        /// <param name="GuestToDelete"></param>
        public static void DeleteGuest(Guest GuestToDelete)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverurl);
                client.DefaultRequestHeaders.Clear();

                try
                {
                    var responce = client.DeleteAsync("Api/Guest/" + GuestToDelete._id).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
