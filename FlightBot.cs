using CsvHelper;
using HtmlAgilityPack;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace FlightBot
{
    class FlightScraper
    {
        static void Main(string[] args)
        {
            var url = "https://www.google.com/travel/flights/search?tfs=CBwQAhooagwIAhIIL20vMGZfXzESCjIwMjItMDgtMDZyDAgDEggvbS8wZjJ2MBooagwIAxIIL20vMGYydjASCjIwMjItMDgtMTByDAgCEggvbS8wZl9fMXABggELCP___________wFAAUgBmAEB";
            
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url);

            Console.WriteLine(html.Result);
            Console.ReadLine();
         }
    }
}
