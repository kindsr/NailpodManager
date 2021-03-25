using NailPodManager.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace NailPodManager.ViewModel
{
    public class M0300_MainViewModel : BaseViewModel
    {
#if DEBUG
        private const string Host = "http://irobotech.iptime.org:5000/";
#else
        private const string Host = "http://45.115.155.4:5000/";
#endif
        private const string SelectMaster = "nailpod/selectMaster";

        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Nailpod> Nailpods { get; }
        public Command GetNailpodsCommand { get; }

        public M0300_MainViewModel()
        {
            Title = "nail POD Manager";
            Nailpods = new ObservableCollection<Nailpod>();
            GetNailpodsCommand = new Command(async () => await GetNailpodsAsync());
            Task.Run(async () => await GetNailpodsAsync());
        }

        async Task GetNailpodsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var json = await Client.GetStringAsync(Host + SelectMaster);
                var nailpods = Nailpod.FromJson(json);

                //Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                //() =>
                //    {
                //        Nailpods.Clear();
                //        foreach (var nailpod in nailpods)
                //            Nailpods.Add(nailpod);
                //    }
                //);
                Nailpods.Clear();
                foreach (var nailpod in nailpods)
                    Nailpods.Add(nailpod);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get nailpods: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
