using System;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Enums;

namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Indicates the underlying [Type] used by the APILogManager 
        /// to create this instance.
        /// </summary>
        string Source { get; }

        /// <summary>
        /// Indicates the specific type of this Logger instance.
        /// The default value for this property is [APILoggerType.None].
        /// </summary>
        APILoggerType LogType { get; set; }

        /// <summary>
        /// Indicates the severity level of this Logger instance. The default 
        /// value of this property is [APILoggerLevel.None].
        /// </summary>
        APILoggerLevel LogLevel { get; set; }

        /// <summary>
        /// The date and time that this logger instance was created.
        /// </summary>
        DateTime TimeStamp { get; }

        /// <summary>
        /// The Unique ID associated with the corresponding API Task. 
        /// </summary>
        string EventId { get; set; }

        /// <summary>
        /// Indicates the last known status of the executing Task at 
        /// the time this Logger instance was requested. The default
        /// value for this property is [APITaskStatus.Unknown].
        /// </summary>
        APITaskStatus Status { get; set; }

        /// <summary>
        /// The details associated with this Logger instance.
        /// </summary>
        string Message { get; set; }

    }
}
