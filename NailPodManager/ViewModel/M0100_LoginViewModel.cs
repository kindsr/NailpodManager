using NailPodManager.Model;
using NailPodManager.View;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NailPodManager.ViewModel
{
    public class M0100_LoginViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public M0100_LoginViewModel()
        {
            Title = $"Welcome";
        }

        public M0100_LoginViewModel(INavigation navigation) : this()
        {
            Navigation = navigation;
        }

        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private void Login()
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(Password))
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter ID and Password", "OK");
            else
            {
                if (Id == "admin" && Password == "admin")
                {
                    App.Current.MainPage.DisplayAlert("Login Success", "", "Ok");
                    //Navigate to Wellcom page after successfully login  
                    App.Current.MainPage.Navigation.PushAsync(new M0300_MainPage());
                }
                else
                    App.Current.MainPage.DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
            }
        }
    }
}
