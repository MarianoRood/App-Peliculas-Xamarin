using Android.Webkit;
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
    public partial class DirectoresPage : ContentPage
    {
        private string url = "http://192.168.1.71:8000/api/Directores";
        HttpClient client = new HttpClient();
        private ObservableCollection<Director> _directores;
        public DirectoresPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            activityIndicator.IsRunning = true;
            activityIndicator.IsVisible = true;

            string contenido = await client.GetStringAsync(url);
            List<Director> directores = JsonConvert.DeserializeObject<List<Director>>(contenido);

            _directores = new ObservableCollection<Director>(directores);
            ldirectores.ItemsSource = _directores;

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
            base.OnAppearing();
        }

        private void ldirectores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}