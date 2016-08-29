using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MarvelPress.ShopifyNav.WebAPI.Attributes;
using MarvelPress.ShopifyNav.WebAPI.Models;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarvelPress.ShopifyNav.WebAPI.Controllers.API
{
    public class ShopifyController : ApiController
    {
        private IAPIHandler handler = new APIHandler();
        private IAPILogManager LogManager = new APILogManager(typeof(ShopifyController));

        [HttpPost]
        [Route("processOrder")]
        [AuthorizeShopifyStore(ShopifyStoreId.Marvelpress)]
        public HttpResponseMessage processShopifyOrderData(JObject jObject)
        {
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                MPShopifyOrder shopifyOrder = (MPShopifyOrder)
                    serializer.Deserialize(new JTokenReader(jObject), typeof(MPShopifyOrder));

                this.LogManager.LogInfo("Processing order" + shopifyOrder.OrderId);
                Task.Run(async () => await this.handler.invokeShopifyOrderService(shopifyOrder));

            }
            catch (Exception ex)
            {
                this.LogManager.LogException(ex.ToString());
                Task.Run(async () => await this.handler.invokeNotificationService(LogManager.ToString()));
            }

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
