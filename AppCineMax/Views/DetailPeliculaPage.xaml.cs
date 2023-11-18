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
    public partial class DetailPeliculaPage : ContentPage
    {
        Pelicula p;

        public DetailPeliculaPage(Pelicula pelicula)
        {
            InitializeComponent();
            lblCategoriaDuracion.Text = $"{pelicula.categorias.name_category} | {pelicula.duration} Minutos";
            BindingContext = pelicula; // Establece el objeto como contexto de datos
            p = pelicula;
            //CreateRoundButtons();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FuncionesPage(p.id, p.title));
        }
    }
}