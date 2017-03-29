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

        private ObservableCollection<Guest> guestCollection;
        public ObservableCollection<Guest> GuestCollection
        {
            get { return guestCollection; }
            set { guestCollection = value; }
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

            handler = new GuestHandler(this);
            CreateGuestCommand = new RelayCommand(handler.CreateGuest, null);
            DeleteGuestCommand = new RelayCommand(handler.DeleteGuest, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
