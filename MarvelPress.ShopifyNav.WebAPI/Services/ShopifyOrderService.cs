using System;
using System.Threading.Tasks;
using MarvelPress.ShopifyNav.WebAPI.Models;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging;

namespace MarvelPress.ShopifyNav.WebAPI.Services
{
    public class ShopifyOrderService : IAPITaskService
    {
        private IAPILogManager LogManager { get; set; }

        public ShopifyOrderService()
        {
            this.LogManager = new APILogManager(this.GetType());
        }

        async Task<bool> IAPITaskService.processAPIRequest(MPShopifyOrder shopifyOrder)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                this.LogManager.LogException(ex.ToString());
                //TODO: call notification service

                throw;
            }

            return false;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ShopifyOrderService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}