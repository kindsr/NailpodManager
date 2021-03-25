using NailPodManager.Model;
using NailPodManager.ViewModel;
using Xamarin.Forms;

namespace NailPodManager.View
{
    public partial class M0300_MainPage : ContentPage
    {
        public M0300_MainPage()
        {
            InitializeComponent();
            BindingContext = new M0300_MainViewModel();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var nailpod = e.SelectedItem as Nailpod;
            if (nailpod == null)
                return;

            await Navigation.PushAsync(new M0400_DetailsPage(nailpod));

            ((ListView)sender).SelectedItem = null;
        }
    }
}
