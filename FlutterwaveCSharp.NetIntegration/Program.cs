using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FlutterwaveCSharp.NetIntegration
{
    public class Program
    {
        //[STAThread]
        //static async Task Main(string[] args)
        //{
            
        //    // new Task(() => {  }).Start();

           
        //    //}

        //}

        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string url = await ProcessOnlinePayment();
           // Redirect()
        }
        private async static Task<string> ProcessOnlinePayment()
        {
            var response = new HttpResponseMessage();
            PaymentDetails payment = new PaymentDetails();
            payment.customizations = new Customizations();
            payment.customer = new Customer();
            payment.meta = new Meta();
            payment.amount = "100000";
            payment.currency = "NGN";
            payment.customer.name = "Gold Eriife";
            payment.customer.email = "customer@processpayment.com";
            payment.customer.phonenumber = "081777777777";
            payment.customizations.description = "business description";
            payment.customizations.logo = "https://processpayment.com/images/logo.png";
            payment.customizations.title = "My Business";
            payment.tx_ref = "000012322";
            payment.redirect_url = "https://processpayment.com/Customer/Payment/PaymentSuccess";
            payment.payment_options = "card,banktransfer,account,ussd";
            payment.meta.consumer_id = 50089;
            payment.meta.consumer_mac = Guid.NewGuid().ToString();

            var jsonString = new JavaScriptSerializer().Serialize(payment);
            var json = JObject.Parse(jsonString).ToString();
            string secret = ConfigurationManager.AppSettings["flutterwave_secret"];
            string server = ConfigurationManager.AppSettings["flutterwave_server"];
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, server);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", secret);


                response = await client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();

                JObject objLogin = JsonConvert.DeserializeObject<dynamic>(content);

                FlutResponse result = JsonConvert.DeserializeObject<FlutResponse>(content);

                return result.data.link;
            }
            
    }

       



        public class Meta
        {
            public int consumer_id { get; set; }
            public string consumer_mac { get; set; }

        }
        public class Customer
        {
            public string email { get; set; }
            public string phonenumber { get; set; }
            public string name { get; set; }

        }
        public class Customizations
        {
            public string title { get; set; }
            public string description { get; set; }
            public string logo { get; set; }

        }
        public class PaymentDetails
        {
            public string tx_ref { get; set; }
            public string amount { get; set; }
            public string currency { get; set; }
            public string redirect_url { get; set; }
            public string payment_options { get; set; }
            public Meta meta { get; set; }
            public Customer customer { get; set; }
            public Customizations customizations { get; set; }

        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
        public class Data
        {
            public string link { get; set; }
        }

        public class FlutResponse
        {
            public string status { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
        }


    }
}
