using NailPodManager.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NailPodManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class M0420_ErrorInfoPage : ContentPage
    {
        public M0420_ErrorInfoPage()
        {
            InitializeComponent();
        }
        public M0420_ErrorInfoPage(int machineId)
        {
            InitializeComponent();
            BindingContext = new M0420_ErrorInfoViewModel(machineId);
        }
    }
}