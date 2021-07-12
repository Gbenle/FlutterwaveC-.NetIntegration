# FlutterwaveC-.NetIntegration
Fluuterwave is a payment gateway company. As a .Net developer there a number of difficulty we face integrating the gateway into our applications without installing their .Net SDK. This is just a work around developed to achieve what we wanted.

# Add the following references
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
 
# How to use it in Asp.NET Webform and MVC Razor
 string url = await ProcessOnlinePayment();
 the "url" is the flutterwave payment page
# What is done
We use Flutterwave Standard Integration Parameter that is in JSON convert it to C# Objects.
Insert our parameters and convert it back to JSON send it Endpoint: https://api.flutterwave.com/v3/payments.
The result was also converted to C# then the payment URl

