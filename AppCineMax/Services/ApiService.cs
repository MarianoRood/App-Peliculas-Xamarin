using AppCineMax.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AppCineMax.Services
{
    public class ApiService
    {
        private string url = "http://192.168.1.71:8000/api/Categorias";
        HttpClient client = new HttpClient();

        public async void getCategories()
        {
            string contenido = await client.GetStringAsync(url + "Categorias");
            List<Categoria> categorias = JsonConvert.DeserializeObject<List<Categoria>>(contenido);
        }
    }
}
