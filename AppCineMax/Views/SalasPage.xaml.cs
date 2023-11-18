using AppCineMax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCineMax.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SalasPage : ContentPage
    {
        private int Rows = 0;
        private int Columns = 0;

        public SalasPage(Sala sala)
        {
            InitializeComponent();
            Rows = sala.rows;
            Columns = sala.cols;
            CreateSeatGrid();

        }

        private void CreateSeatGrid()
        {
            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < Columns; j++)
                {
                    var seatButton = new ImageButton
                    {
                        Source = "available_seat.png", // Ajusta esto al nombre de tu imagen
                        WidthRequest = 60,
                        HeightRequest = 60,
                        Margin = new Thickness(1, 3),
                        BackgroundColor = Color.Transparent,
                        BorderColor = Color.Black,
                        Padding = new Thickness(0, 0, 0, 3)
                        //CornerRadius = 30, // Esto dará forma circular al botón
                        //ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Top, 5)
                    };

                    seatButton.Clicked += OnSeatClicked;

                    seatGrid.Children.Add(seatButton, j, i);
                }
            }
        }

        private void OnSeatClicked(object sender, EventArgs e)
        {
            var seatButton = (ImageButton)sender;

            if (seatButton.Source.ToString().Contains("available_seat"))
            {
                seatButton.Source = "selected_seat.png"; // Ajusta esto al nombre de tu imagen ocupada
            }
            else
            {
                seatButton.Source = "available_seat.png";
            }
        }

        private async void OnReserveSeatClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ReservaPage());
        }
    }
}