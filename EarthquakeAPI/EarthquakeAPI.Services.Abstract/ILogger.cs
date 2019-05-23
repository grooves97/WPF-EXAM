using System;

namespace EarthquakeAPI.Services.Abstract
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogMessage(string text);
    }
}
