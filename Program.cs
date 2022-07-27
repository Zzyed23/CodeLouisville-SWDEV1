using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace EbayBotTwo
{
    class Bot
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            HtmlASync();
        }

        private static async void  HtmlASync()
        {
            var url = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313&_nkw=yeezy&_sacat=0";
           
            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
          
            var ItemList = htmlDoc.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("srp-results__clear")).ToList();

            //var itemListItems = ItemList[0].Descendants("li")
                //.Where(node => node.GetAttributeValue("id", ""));
              
            Console.WriteLine();
        }

    }
}