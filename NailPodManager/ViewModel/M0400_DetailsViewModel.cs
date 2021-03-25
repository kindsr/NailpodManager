using NailPodManager.Model;
using NailPodManager.View;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NailPodManager.ViewModel
{
    public class M0400_DetailsViewModel : BaseViewModel
    {
        public Command GetPaymentCommand { get; }
        public Command GetErrorInfoCommand { get; }

        public INavigation Navigation { get; set; }

        public M0400_DetailsViewModel()
        {

        }

        public M0400_DetailsViewModel(INavigation navigation) : this()
        {
            Navigation = navigation;
        }

        public M0400_DetailsViewModel(INavigation navigation, Nailpod nailpod) : this(navigation)
        {
            Nailpod = nailpod;
            Title = $"#{Nailpod.MachineId} Details";
            GetPaymentCommand = new Command(async () => await GetPaymentAsync());
            GetErrorInfoCommand = new Command(async () => await GetErrorInfoAsync());
        }

        Nailpod nailpod;
        public Nailpod Nailpod
        {
            get => nailpod;
            set
            {
                if (nailpod == value)
                    return;

                nailpod = value;
                OnPropertyChanged();
            }
        }

        async Task GetPaymentAsync()
        {
            if (IsBusy)
                return;

            await Navigation.PushAsync(new M0410_PaymentPage(Nailpod.MachineId));
        }

        async Task GetErrorInfoAsync()
        {
            if (IsBusy)
                return;

            await Navigation.PushAsync(new M0420_ErrorInfoPage(Nailpod.MachineId));
        }
    }
}
