using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guest_app.Model;
using System.Windows.Input;
using Guest_app.Common;
using System.ComponentModel;
using Guest_app.Handler;

namespace Guest_app.ViewModel
{
    class GuestViewModel : INotifyPropertyChanged
    {
        public GuestHandler handler;

        public ICommand CreateGuestCommand { get; set; }
        public ICommand DeleteGuestCommand { get; set; }
        public ICommand UpdateGuestCommand { get; set; }

        private ObservableCollection<Guest> guestCollection;
        public ObservableCollection<Guest> GuestCollection
        {
            get { return guestCollection; }
            set { guestCollection = value; }
        }

        private ObservableCollection<GuestBookings> guestbookingcollection;
        public ObservableCollection<GuestBookings> Guestbookingcollection
        {
            get { return guestbookingcollection; }
            set { guestbookingcollection = value; }
        }

        private Guest selectedGuest;
        public Guest SelectedGuest
        {
            get { return selectedGuest; }
            set
            {
                selectedGuest = value;
                OnPropertyChanged(nameof(SelectedGuest));
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(id));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(address));
            }
        }

        public GuestViewModel()
        {
            guestCollection = new ObservableCollection<Guest>();
            guestCollection = GuestSingleton.Instance.GuestCollection;

            guestbookingcollection = new ObservableCollection<GuestBookings>();
            guestbookingcollection = GuestSingleton.Instance.Temp_list;

            handler = new GuestHandler(this);
            CreateGuestCommand = new RelayCommand(handler.CreateGuest, null);
            DeleteGuestCommand = new RelayCommand(handler.DeleteGuest, null);
            UpdateGuestCommand = new RelayCommand(handler.UpdateGuest, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
