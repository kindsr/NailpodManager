using NailPodManager.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NailPodManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class M0100_LoginPage : ContentPage
    {
        public M0100_LoginPage()
        {
            InitializeComponent();
            BindingContext = new M0100_LoginViewModel();
        }

        //private void btnLogin_Click(object sender, System.EventArgs e)
        //{
        //    //null or empty field validation, check weather email and password is null or empty  
        //    if (string.IsNullOrEmpty(Id.Text) || string.IsNullOrEmpty(Password.Text))
        //        DisplayAlert("Empty Values", "Please enter ID and Password", "OK");
        //    else
        //    {
        //        if (Id.Text == "admin" && Password.Text == "admin")
        //        {
        //            DisplayAlert("Login Success", "", "Ok");
        //            //Navigate to Wellcom page after successfully login  
        //            Navigation.PushAsync(new M0300_MainPage());
        //        }
        //        else
        //            DisplayAlert("Login Fail", "Please enter correct Email and Password", "OK");
        //    }
        //}
    }
}