using Microsoft.Extensions.Logging;

namespace LoggerService.Logging
{
    public class CustomLoggerProviderConfiguration
    {
        public LogLevel LogLevel { get; set; } = LogLevel.Trace;
        public int EventId { get; set; } = 0;
    }
}
