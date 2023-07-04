using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main()
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                string apiUrl = "http://129.80.203.120:5000/post-accounting-entries";

                
                client.DefaultRequestHeaders.Add("Content-Type", "application/json");

               
                var requestBody = new
                {
                    descripcion = "juan pablo klk",
                    auxiliar = 1,
                    cuentaDB = 1,
                    cuentaCR = 1,
                    monto = 1000.45
                };

                var jsonBody = System.Text.Json.JsonSerializer.Serialize(requestBody);

               
                var requestContent = new StringContent(jsonBody, System.Text.Encoding.UTF8, "application/json");

               
                HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                if (response.IsSuccessStatusCode)
                {
                   
                    string jsonResponse = await response.Content.ReadAsStringAsync();

            
                    Console.WriteLine("Solicitud exitosa");
                }
                else
                {
                   
                    Console.WriteLine("Error en la solicitud: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la solicitud: " + ex.Message);
            }
        }
    }
}
