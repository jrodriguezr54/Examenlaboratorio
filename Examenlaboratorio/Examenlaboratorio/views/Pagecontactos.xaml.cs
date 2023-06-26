using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examenlaboratorio.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pagecontactos : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile photo = null;

        public Byte[] GetimagesBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] fotobyte = memory.ToArray();

                    return fotobyte;
                }
            } 
            return null;
        }
        public Pagecontactos()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            var contacto = new models.contacto
            {
                nombres = nombres.Text,
                apellidos = apellidos.Text,
                edad = edad.Text,
                pais = Pais.SelectedItem.ToString(),
                nota = nota.Text,
                telefono = telefono.Text,
                foto = GetimagesBytes()

            };

            if (photo != null)
            {
                if (await App.Database.addcontacto(contacto) > 0)
                {
                    await DisplayAlert("AVISO", "Contacto guardado exitosamente" + nombres.Text + " " + apellidos.Text, "OK");
                }
                else
                {
                    await DisplayAlert("AVISO", "Ocurrio un error", "OK");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Favor tome una foto primero", "OK");
            }
        }

        private async void btnfoto_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "APP",
                Name = "Foto.jpg",
                SaveToAlbum = true

            });

            if (photo != null)
            {
                foto.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }

        }
    }
}