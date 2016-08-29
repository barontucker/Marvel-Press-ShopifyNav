using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging;

namespace MarvelPress.ShopifyNav.WebAPI.Attributes
{
    public enum ShopifyStoreId : long { Marvelpress = 021545645, Default = -11001 }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public sealed class AuthorizeShopifyStore : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        private ShopifyStoreId storeId = ShopifyStoreId.Default;
        private IAPILogManager LogManager = new APILogManager(typeof(AuthorizeShopifyStore));

        public AuthorizeShopifyStore()
        { }

        public AuthorizeShopifyStore(ShopifyStoreId storeId)
        {
            this.storeId = storeId;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (!valid("101010101011101111001100110111011110111011111111"))
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                    return;

                }
            }
            catch (Exception ex)
            {
                this.LogManager.LogException(ex.ToString());
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Conflict);
                throw;
            }

            base.OnAuthorization(actionContext);
        }

        private bool valid(string sharedSecretKey)
        {
            // get the body of the request and convert to bytes for hashing
            string data = GetStreamAsText(HttpContext.Current.Request.InputStream, HttpContext.Current.Request.ContentEncoding);
            byte[] keyBytes = Encoding.UTF8.GetBytes(sharedSecretKey);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            //use the SHA256Managed Class to compute the hash
            HMACSHA256 hmac = new HMACSHA256(keyBytes);
            byte[] hmacBytes = hmac.ComputeHash(dataBytes);

            // retun as base64 string. Compare with the signature passed in the header 
            // of the post request from Shopify. If they match, the call is verified.
            string hmacHeader = HttpContext.Current.Request.Headers["x-shopify-hmac-sha256"];
            string createSignature = Convert.ToBase64String(hmacBytes);
            return hmacHeader == createSignature;

        }

        private string GetStreamAsText(Stream stream, Encoding encoding)
        {
            Int64 bytesToGet = stream.Length;
            byte[] input = new byte[bytesToGet];
            stream.Read(input, 0, (int)bytesToGet);
            stream.Seek(0, SeekOrigin.Begin);
            return encoding.GetString(input);
        }

    }
}