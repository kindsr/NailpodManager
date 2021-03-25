using NailPodManager.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NailPodManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class M0410_PaymentPage : ContentPage
    {
        public M0410_PaymentPage()
        {
            InitializeComponent();
        }
        public M0410_PaymentPage(int machineId)
        {
            InitializeComponent();
            BindingContext = new M0410_PaymentViewModel(machineId);
        }
    }
}