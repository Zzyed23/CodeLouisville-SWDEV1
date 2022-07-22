using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightFare
{
    class Email
    {
        static async Task Main(string[] args)
        {
            var sender = new SmtpSender(() => new SmtpClient(HostExecutionContext: "gmail"));
            {
                Console.WriteLine("Please enter your email address:");
                Console.ReadLine();
                Console.WriteLine("Please eneter Destination");
                Console.ReadLine();
                Console.WriteLine("Please enter price desired");
                Console.ReadLine();
                EnableSs1 = false
                DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
                PickupDirectoryLocation = @"gmail"
            });

            Email.DefaulSender = sender;

            var email = await Email
                .From(emailAddress: "Flighrfarebot@gmail.com")
                .To(emailAddress: "")
                .Subject("Youre flight for %s has been found for a matching price")
                .SendAsync();
     
        }
    }
}