using System;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Enums;

namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging
{
    public interface IAPILogManager : IDisposable
    {
        void LogException(string exception, string message = "Exception: ", APILoggerLevel loggerLevel = APILoggerLevel.Critical);

        void LogError(string message, APILoggerLevel loggerLevel = APILoggerLevel.High);

        void LogWarning(string message, APILoggerLevel loggerLevel = APILoggerLevel.Low);

        void LogInfo(string message, APILoggerLevel loggerLevel = APILoggerLevel.Normal);
    }
}
