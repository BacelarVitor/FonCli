
using System;
using System.Net.Http;
using System.Threading.Tasks;

using (HttpClient client = new HttpClient())
{
    string username = "BacelarVitor";
    string apiUrl = $"https://github.com/{username}";

    client.DefaultRequestHeaders.Add("User-Agent", "MyApp"); // GitHub API requires a User-Agent header

    HttpResponseMessage response = await client.GetAsync(apiUrl);
    response.EnsureSuccessStatusCode();

    string responseBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine(responseBody);
}


