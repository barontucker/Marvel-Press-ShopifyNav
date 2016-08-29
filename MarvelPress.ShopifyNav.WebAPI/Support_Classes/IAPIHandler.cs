using System.Threading.Tasks;
using MarvelPress.ShopifyNav.WebAPI.Models;

namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes
{
    interface IAPIHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        Task<bool> invokeShopifyOrderService(MPShopifyOrder shopifyOrder);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationMessage"></param>
        /// <returns></returns>
        Task<bool> invokeNotificationService(string notificationMessage);
    }
}
