namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes.Enums
{
    public enum APITaskStatus
    {
        Unknown,
        Created,
        Validated,
        Sent,
        Falied
    }

    public enum APILoggerType
    {
        None,
        Info,
        Warning,
        Error,
        Exception
    }

    public enum APILoggerLevel
    {
        None,
        Normal,
        Low,
        High,
        Critical
    }
}