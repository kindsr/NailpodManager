using NailPodManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NailPodManager.ViewModel
{
    public class M0420_ErrorInfoViewModel : BaseViewModel
    {
#if DEBUG
        private const string Host = "http://irobotech.iptime.org:5000/";
#else
        private const string Host = "http://45.115.155.4:5000/";
#endif
        private const string SelectPayment = "nailpod/selectErrorInfo/{0}";

        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<ErrorInfo> ErrorInfos { get; }
        public Command GetErrorInfosCommand { get; }

        public M0420_ErrorInfoViewModel()
        {

        }

        public M0420_ErrorInfoViewModel(int machineId) : this()
        {
            Title = string.Format("#{0} Error Info", machineId);
            ErrorInfos = new ObservableCollection<ErrorInfo>();
            GetErrorInfosCommand = new Command(async () => await GetErrorInfosAsync(machineId));
            IsBusy = false;
            Task.Run(async () => await GetErrorInfosAsync(machineId));
        }

        async Task GetErrorInfosAsync(int machineId)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var json = await Client.GetStringAsync(string.Format(Host + SelectPayment, machineId));
                var errorInfos = ErrorInfo.FromJson(json);

                //Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                //() =>
                //    {
                //        ErrorInfos.Clear();
                //        foreach (var error in errorInfos)
                //            ErrorInfos.Add(error);
                //    }
                //);
                ErrorInfos.Clear();
                foreach (var error in errorInfos)
                    ErrorInfos.Add(error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Errors: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
