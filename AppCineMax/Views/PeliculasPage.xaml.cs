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
    public partial class PeliculasPage : ContentPage
    {
        int cat = 0;
        int type = 0;

        private string url = "http://192.168.1.71:8000/api/";
        HttpClient client = new HttpClient();
        private ObservableCollection<Pelicula> _pelicula;

        public PeliculasPage()
        {
            InitializeComponent();
        }

        public PeliculasPage(int id, int ty)
        {
            InitializeComponent();
            type = ty;
            cat = id;
        }

        protected override async void OnAppearing()
        {
            PeliculaCategoria pelicula_categoria;
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;

            if(type != 0)
            {
                pelicula_categoria = new PeliculaCategoria { categoria = cat };
                url += "get-peliculas-cat";
            }
            else
            {
                pelicula_categoria = new PeliculaCategoria { categoria = cat };
                url += "get-peliculas";
            }

            var json = JsonConvert.SerializeObject(pelicula_categoria);

            // Configura el encabezado de la solicitud (si es necesario)
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            // Convierte el contenido en formato json en un objeto StringContent
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // Realiza la solicitud POST
            HttpResponseMessage contenido = await client.PostAsync(url, content);

            if (contenido.IsSuccessStatusCode)
            {
                string responseContent = await contenido.Content.ReadAsStringAsync();
                List<Pelicula> peliculas = JsonConvert.DeserializeObject<List<Pelicula>>(responseContent);

                _pelicula = new ObservableCollection<Pelicula>(peliculas);

                lpeliculas.ItemsSource = _pelicula;
            }
            else
            {

            }


            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
            base.OnAppearing();
        }

        private async void lpeliculas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //DisplayAlert("Seleccionado", $"{pelicula.short_description}", "ok");

            if (e.SelectedItem is Pelicula pelicula)
            {
                //Console.WriteLine(pelicula);
                // Aquí puedes pasar la información a la nueva página
                await Navigation.PushAsync(new DetailPeliculaPage(pelicula));

                // Deselecciona el elemento en la lista
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}