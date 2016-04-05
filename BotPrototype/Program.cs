using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BotPrototype
{
    class Program
    {
        static void Main()
        {
            Task t = new Task(DownloadPageAsync);
            t.Start();
            Console.WriteLine("Talking to URI");
            Console.ReadKey();
        }

        static async void DownloadPageAsync()
        {
            // Target URI
            string page = "https://api.telegram.org/bot165880522:AAGbVct0JDttkPYVdpGnTMzyRwQqjM9toEg/setWebhook?url=https://www.learninhindi.com/Home/Response";

            // HttpClient
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // Read the string
                string result = await content.ReadAsStringAsync();

                // Display the result
                if (result != null)
                {
                    Console.Write(result);
                }
            }
        }
    }
}
