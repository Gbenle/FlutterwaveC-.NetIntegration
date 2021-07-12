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
