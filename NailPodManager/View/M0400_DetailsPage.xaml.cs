using NailPodManager.Model;
using NailPodManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NailPodManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class M0400_DetailsPage : ContentPage
    {
        public M0400_DetailsPage()
        {
            InitializeComponent();
        }

        public M0400_DetailsPage(Nailpod nailpod)
        {
            InitializeComponent();
            BindingContext = new M0400_DetailsViewModel(Navigation, nailpod);
        }
    }
}