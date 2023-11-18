using AppCineMax.Models;
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
    public partial class CategoriasPage : ContentPage
    {
        private string url = "http://192.168.1.71:8000/api/Categorias";
        HttpClient client = new HttpClient();
        private ObservableCollection<Categoria> _categorias;

        public CategoriasPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;

            string contenido = await client.GetStringAsync(url);
            List<Categoria> categorias = JsonConvert.DeserializeObject<List<Categoria>>(contenido);

            _categorias = new ObservableCollection<Categoria>(categorias);
            lcategorias.ItemsSource = _categorias;

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
            base.OnAppearing();
        }

        private async void lcategorias_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var categoria = e.SelectedItem as Categoria;

            if(categoria != null)
            {
                await Navigation.PushAsync(new PeliculasPage(categoria.id, 1));
                ((ListView)sender).SelectedItem = null;
            }
            else
            {
                ((ListView)sender).SelectedItem = null;
            }
        }
    }
}