using MvcConsumoPersonajesServerEGPB.Models;
using System.Net.Http.Headers;

namespace MvcConsumoPersonajesServerEGPB.Services
{
    public class ServiceCrudPersonajes
    {
        private string urlApi;
        private MediaTypeWithQualityHeaderValue Header;
        public ServiceCrudPersonajes(IConfiguration configuration)
        {
            this.urlApi = configuration.GetValue<string>("ApiUrls:ApiCrudPersonajes");
            this.Header =
                new MediaTypeWithQualityHeaderValue("application/json");
        }

        //METODO GENERICO

        private async Task<T> CallApiAsync<T>(string request)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else{
                    return default(T);
                }
            }
        }

        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            string request = "/api/personajes";
            List<Personaje> personajes = await
                this.CallApiAsync<List<Personaje>>(request);
            return personajes;
        }
        public async Task<Personaje> FindPersonajeAsync(int idpersonaje)
        {
            string request = "/api/personajes/" +idpersonaje;
            Personaje personaje = await
                this.CallApiAsync<Personaje>(request);
            return personaje;
        }

        public async Task InsertNuevoPersonajeAsync(int idpersonaje, string personaje, string imagen, int idserie)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/personajes/InsertarPersonaje/" + idpersonaje + "/" + personaje + "/" + imagen + "/" + idserie;
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);

                HttpResponseMessage reponse =
                    await client.PostAsync(request, null);
            }
        } 
        public async Task UpdatePersonajeAsync(int idpersonaje, string personaje, string imagen, int idserie)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "/api/personajes/UpdatePersonaje/" + idpersonaje + "/" + personaje + "/" + imagen + "/" + idserie;
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage reponse =
                    await client.PutAsync(request, null);
            }
        }
        public async Task DeletePersonajeAsync(int idpersonaje)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "/api/personajes/" + idpersonaje;
                client.BaseAddress = new Uri(this.urlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage reponse =
                    await client.DeleteAsync(request);
            }
        }
    }
}
