using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HtmlAgilityPack;  //using the HTMLagility pack to make our parsing easier
using System.Collections.Generic;
using System.Linq;



namespace PS5bot
{
    class Program
    {

        static void Main(string[] args)
        {
            GetHtmlAsync();
            Console.ReadLine();

        }
        private static async void GetHtmlAsync()
        {  //URL we will be using to parse. I chose a link for PS5 lisitings
            var url = "https://www.ebay.com/sch/i.html?LH_SALE_CURRENCY=0&_dmd=1&_ex_kw=&_fpos=40219&_fsct=&_fspt=1&_ftrt=901&_ftrv=1&_in_kw=1&_ipg=60&_nkw=ps5&_sabdhi=&_sabdlo=&_sacat=0&_sadis=10&_samihi=&_samilow=&_sofindtype=5&_sop=12&_udhi=&_udlo=&_fosrp=1";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url); 

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var ProductsHtml = htmlDocument.DocumentNode.Descendants("ul") //ul is a unordered list we will be trying to obtain
                .Where(node => node.GetAttributeValue("id", "") //looking for the token "id" 
                .Equals("ListViewInner")).ToList(); 

            var ProductListItems = ProductsHtml[0].Descendants("li")//li is a list of items we want
                .Where(node => node.GetAttributeValue("id", "")//another id token
                .Contains("item")).ToList();

            Console.WriteLine(ProductListItems.Count() + " Listings");
            Console.WriteLine();

            foreach (var Product in ProductListItems)
            {
                //name of the item
                Console.WriteLine("Product: " + Product.Descendants("h3")
                    .Where(node => node.GetAttributeValue("class", "")
                    .Contains("lvtitle")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')
                    );
                //lvtitle is used for the name of the product

                //Price
                Console.WriteLine("Price: " +
                        Product.Descendants("li")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Contains("lvprice prc")).FirstOrDefault().InnerText.Trim('\r', '\n', '\t')  //lvprice is the common marker that we will look for when trying to obtain the price

                    );

                //URL direct link for the item
                Console.WriteLine("URL: " +
                        Product.Descendants("a")
                        .Where(node => node.GetAttributeValue("class", "")
                        .Contains("vip")).FirstOrDefault().GetAttributeValue("href", "")
                        );
                //vip is the marker for the url of the item

                Console.WriteLine();
            }

        }
    }
}

