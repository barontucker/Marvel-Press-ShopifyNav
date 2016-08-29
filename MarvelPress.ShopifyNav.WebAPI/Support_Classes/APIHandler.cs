using System;
using System.Threading.Tasks;
using MarvelPress.ShopifyNav.WebAPI.Models;
using MarvelPress.ShopifyNav.WebAPI.Services;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging;

namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes
{
    public class APIHandler : IAPIHandler
    {
        private IAPILogManager LogManager = new APILogManager(typeof(APIHandler));

        public APIHandler()
        { }

        async Task<bool> IAPIHandler.invokeShopifyOrderService(MPShopifyOrder shopifyOrder)
        {
            try
            {
                using (IAPITaskService service = new ShopifyOrderService())
                {
                    await service.processAPIRequest(shopifyOrder);
                }
            }
            catch (Exception ex)
            {
                this.LogManager.LogException(ex.ToString());
                // TODO: call notification service
                // swallow the exception, as the Http response has already been returned
            }

            return false;
        }

        async Task<bool> IAPIHandler.invokeNotificationService(string notificationMessage)
        {
            throw new NotImplementedException();
        }
    }
}