using System;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Enums;

namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging
{
    public class APILogManager : IAPILogManager
    {
        private ILogger Logger { get; set; }

        public APILogManager(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("LogType");

            this.Logger = new Logger(type.ToString());
        }

        void IAPILogManager.LogError(string message, APILoggerLevel loggerLevel)
        {
            this.Logger.LogType = APILoggerType.Error;
            this.Logger.LogLevel = loggerLevel;
            this.Logger.Message = message;
        }

        void IAPILogManager.LogException(string exception, string message, APILoggerLevel loggerLevel)
        {
            this.Logger.LogType = APILoggerType.Exception;
            this.Logger.LogLevel = loggerLevel;
            this.Logger.Message = message;
        }

        void IAPILogManager.LogWarning(string message, APILoggerLevel loggerLevel)
        {
            this.Logger.LogType = APILoggerType.Warning;
            this.Logger.LogLevel = loggerLevel;
            this.Logger.Message = message;
        }

        void IAPILogManager.LogInfo(string message, APILoggerLevel loggerLevel)
        {
            this.Logger.LogType = APILoggerType.Info;
            this.Logger.LogLevel = loggerLevel;
            this.Logger.Message = message;
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
        // ~APILogManager() {
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