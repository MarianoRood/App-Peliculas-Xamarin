using AppCineMax.Models;
using AppCineMax.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCineMax.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FuncionesPage : ContentPage
    {
        private string url = "http://192.168.1.71:8000/api/get-funciones";
        HttpClient client = new HttpClient();
        int p;
        private ObservableCollection<Funcion> _funciones;

        public FuncionesPage(int id, string name)
        {
            InitializeComponent();
            p = id;
            name_pelicula.Text = name;
        }

        protected override async void OnAppearing()
        {
            FuncionPelicula funcion_pelicula;

            funcion_pelicula = new FuncionPelicula { pelicula_id = p };

            var json = JsonConvert.SerializeObject(funcion_pelicula);

            // Configura el encabezado de la solicitud (si es necesario)
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Convierte el contenido en formato json en un objeto StringContent
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realiza la solicitud POST
            HttpResponseMessage contenido = await client.PostAsync(url, content);

            if (contenido.IsSuccessStatusCode)
            {
                string responseContent = await contenido.Content.ReadAsStringAsync();
                List<Funcion> funciones = JsonConvert.DeserializeObject<List<Funcion>>(responseContent);

                _funciones = new ObservableCollection<Funcion>(funciones);
                //FuncionesButtons(funciones);
                lfunciones.ItemsSource = _funciones;
            }
            else
            {

            }
            base.OnAppearing();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var funcion = button.BindingContext as Funcion; // Asegúrate de cambiar esto por tu modelo real
            if (funcion != null)
            {
                await Navigation.PushAsync(new SalasPage(funcion.salas));
                
            }
        }

        private async void lfunciones_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var funcion = e.SelectedItem as Funcion;

            if (funcion != null)
            {
                await Navigation.PushAsync(new SalasPage(funcion.salas));
                ((ListView)sender).SelectedItem = null;
            }
            else
            {
                ((ListView)sender).SelectedItem = null;
            }

        }
    }
}