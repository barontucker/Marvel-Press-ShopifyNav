using System;
using MarvelPress.ShopifyNav.WebAPI.Support_Classes.Enums;

namespace MarvelPress.ShopifyNav.WebAPI.Support_Classes.Logging
{
    public class Logger : ILogger
    {
        /// <summary>
        /// Creates a Type specific logger instance with the requied Source[Type].
        /// </summary>
        /// <param name="source"></param>
        public Logger(string source)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentException("Source");

            this.timeStamp = DateTime.UtcNow;
            this.source = source;
        }

        /// <summary>
        /// The Unique ID associated with the corresponding API Task. 
        /// </summary>
        string ILogger.EventId
        {
            get
            {
                return this.eventId;
            }

            set
            {
                this.eventId = value;
            }
        }

        private string eventId;

        /// <summary>
        /// Indicates the severity level of this Logger instance. The default 
        /// value of this property is [APILoggerLevel.None].
        /// </summary>
        APILoggerLevel ILogger.LogLevel
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        private APILoggerLevel level = APILoggerLevel.None;

        /// <summary>
        /// The details associated with this Logger instance.
        /// </summary>
        string ILogger.Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        private string message;

        /// <summary>
        /// Indicates the underlying [Type] used by the APILogManager 
        /// to create this instance.
        /// </summary>
        string ILogger.Source
        {
            get
            {
                return this.source;
            }
        }

        private string source;

        /// <summary>
        /// Indicates the last known status of the executing Task at 
        /// the time this Logger instance was requested. The default
        /// value for this property is [APITaskStatus.Unknown].
        /// </summary>
        APITaskStatus ILogger.Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        private APITaskStatus status = APITaskStatus.Unknown;

        /// <summary>
        /// The date and time that this Logger instance was created.
        /// </summary>
        DateTime ILogger.TimeStamp
        {
            get
            {
                return this.timeStamp;
            }
        }

        private DateTime timeStamp;

        /// <summary>
        /// Indicates the specific type of this Logger instance.
        /// The default value for this property is [APILoggerType.None].
        /// </summary>
        APILoggerType ILogger.LogType
        {
            get
            {
                return this.logType;
            }

            set
            {
                this.logType = value;
            }
        }

        private APILoggerType logType = APILoggerType.None;

    }
}