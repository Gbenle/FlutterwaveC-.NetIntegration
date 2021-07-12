# FlutterwaveC# Asp.Net Integration
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
We use Flutterwave Standard Integration Parameters which is in JSON format. Converted it to C# Objects.
Insert our parameters and convert it back to JSON send it to Endpoint: https://api.flutterwave.com/v3/payments.
The result was also converted back to C# then the payment URl

Convert JSON to C# object https://json2csharp.com/

