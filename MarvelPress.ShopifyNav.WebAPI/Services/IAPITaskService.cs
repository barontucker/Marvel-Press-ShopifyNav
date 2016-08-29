using System;
using System.Threading.Tasks;
using MarvelPress.ShopifyNav.WebAPI.Models;

namespace MarvelPress.ShopifyNav.WebAPI.Services
{
    public interface IAPITaskService : IDisposable
    {
        Task<bool> processAPIRequest(MPShopifyOrder shopifyOrder);
    }
}
