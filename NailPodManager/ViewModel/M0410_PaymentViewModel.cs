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
    public class M0410_PaymentViewModel : BaseViewModel
    {
#if DEBUG
        private const string Host = "http://irobotech.iptime.org:5000/";
#else
        private const string Host = "http://45.115.155.4:5000/";
#endif
        private const string SelectPayment = "nailpod/selectPayment/{0}";

        HttpClient httpClient;
        HttpClient Client => httpClient ?? (httpClient = new HttpClient());

        public ObservableCollection<Payment> Payments { get; }
        public Command GetPaymentsCommand { get; }

        public M0410_PaymentViewModel()
        {

        }

        public M0410_PaymentViewModel(int machineId) : this()
        {
            Title = string.Format("#{0} Payment Info", machineId);
            Payments = new ObservableCollection<Payment>();
            GetPaymentsCommand = new Command(async () => await GetPaymentsAsync(machineId));
            IsBusy = false;
            Task.Run(async () => await GetPaymentsAsync(machineId));
        }

        async Task GetPaymentsAsync(int machineId)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var json = await Client.GetStringAsync(string.Format(Host + SelectPayment, machineId));
                var payments = Payment.FromJson(json);

                //Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                //() =>
                //    {
                //        Payments.Clear();
                //        foreach (var payment in payments)
                //            Payments.Add(payment);
                //    }
                //);
                Payments.Clear();
                foreach (var payment in payments)
                    Payments.Add(payment);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get payments: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }

}
