using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examenlaboratorio.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pageinicial : ContentPage
    {
        public Pageinicial()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listcontactos.ItemsSource = await App.Database.obtenerlistacontacto();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var Pagecontact = new views.Pagecontactos();
            Navigation.PushAsync(Pagecontact);
        }
    }
}