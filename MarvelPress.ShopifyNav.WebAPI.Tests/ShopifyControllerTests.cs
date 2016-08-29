using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using MarvelPress.ShopifyNav.WebAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopifyNavWebAPI.Tests
{
    [TestClass]
    public class ShopifyControllerTests
    {
        [TestMethod]
        public void processShopifyOrderDataTest_Mock()
        {
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)
                 WebRequest.Create("http://shopifyNavWebAPI/processOrder");

                request.ContentType = "application/json";
                request.Method = "POST";
                request.Accept = "application/json";

                MPShopifyOrder shopifyOrder =
                    new MPShopifyOrder();

                shopifyOrder.OrderId = "MP-3893249283";
                shopifyOrder.FirstName = "John";
                shopifyOrder.LastName = "Doe";
                shopifyOrder.Address1 = "0001 Some Where Lane";
                shopifyOrder.City = "Some City";
                shopifyOrder.ZipCode = "00000-0000";
                shopifyOrder.Country = "Some Country";
                shopifyOrder.Currency = "USD";
                shopifyOrder.Email = "someone@hotmail.com";
                shopifyOrder.Phone = "000-000-0000";
                shopifyOrder.TrackingNumber = "S53451002123222";

                var json = new JavaScriptSerializer().Serialize(shopifyOrder);

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(json);
                writer.Close();
                response = request.GetResponse() as HttpWebResponse;

                Console.WriteLine(response.StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                // Display the content. 
                Console.WriteLine(responseFromServer);

                // Cleanup the streams and the response.
                reader.Close();
                dataStream.Close();
                response.Close();

                //got a valid response from the server
                Assert.IsNotNull(response);

                response.Close();
                response.Dispose();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }

    }
}