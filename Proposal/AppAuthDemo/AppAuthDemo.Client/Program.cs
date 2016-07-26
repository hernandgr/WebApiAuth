using AppAuthDemo.Client.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppAuthDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            DoWorkAsync().Wait();
        }

        public static async Task<object> DoWorkAsync()
        {
            Console.WriteLine("Requesting token...");

            var token = await GetToken();

            Console.WriteLine("Token: " + token.AccessToken);
            Console.WriteLine("Token type: " + token.TokenType);
            Console.WriteLine("Expires in: " + token.ExpiresIn);

            Console.WriteLine();
            Console.WriteLine("Requesting data...");

            var data = await GetData(token);

            Console.WriteLine("Data: " + data);
            Console.ReadKey();

            return Task.FromResult<object>(null);
        }

        private static async Task<TokenResponse> GetToken()
        {
            TokenResponse response = null;

            var requestData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", "AppAuthDemo"),
                new KeyValuePair<string, string>("client_secret", "123@abc")
            });

            using (var client = GetHttpClient())
            {
                var result = await client.PostAsync("/token", requestData);

                if (result.IsSuccessStatusCode)
                {
                    var responseStr = await result.Content.ReadAsStringAsync();
                    response = JsonConvert.DeserializeObject<TokenResponse>(responseStr);
                }
            }

            return response;
        }

        private static async Task<string> GetData(TokenResponse token)
        {
            using (var client = GetHttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
                return await client.GetStringAsync("/api/orders");
            }
        }

        private static HttpClient GetHttpClient()
        {
            return new HttpClient { BaseAddress = new Uri("http://localhost:19773/") };
        }
    }
}
