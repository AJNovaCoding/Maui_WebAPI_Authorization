using System.Text;
using System.Net.Http.Headers;

namespace MauiLoginAuth.DataAccess
{
    public class UserAuthentication
    {
        public bool AuthenticateUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
                //Set the base address of the API
                client.BaseAddress = new Uri("http://localhost:33426//");

                //Create the authentication header value
                var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

                //Set the endpoint to use the Values controller
                var endpoint = "api/Values";

                //Send Get request
                using var response = client.GetAsync(endpoint).Result;

                var statusCode = response.StatusCode;

                //Return true if the response is successful
                return response.IsSuccessStatusCode;
            }
        }
    }
}
