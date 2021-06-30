using System;
using UnityEngine;

namespace KCTR
{
    /// <summary>
    /// LogLevel enum. Basically the one from Microsoft
    /// </summary>
    public enum LogLevel
    {
        Trace,
        Debug,
        Information,
        Warning,
        Error,
        Critical,
        None
    }

    /// <summary>
    /// Utility class for logging
    /// </summary>
    public static class Logging
    {
        public static LogLevel Level { get; set; } = LogLevel.Information;

        public static void Log(LogLevel level, Exception ex, string message, params object[] args)
        {
            if (level >= Level)
            {
                string updatedMsg = addPrefix(message);
                if (ex != null)
                {
                    Debug.LogException(ex);
                }
                switch (level)
                {
                    case LogLevel.Trace:
                    case LogLevel.Debug:
                    case LogLevel.Information: Debug.LogFormat(updatedMsg, args); break;
                    case LogLevel.Warning: Debug.LogWarningFormat(updatedMsg, args); break;
                    case LogLevel.Error:
                    case LogLevel.Critical: Debug.LogErrorFormat(updatedMsg, args); break;
                    default: break;
                }
            }
        }

        public static void LogDebug(string message, params object[] args) => Log(LogLevel.Debug, null, message, args);
        public static void LogInfo(string message, params object[] args) => Log(LogLevel.Information, null, message, args);
        public static void LogWarning(string message, params object[] args) => Log(LogLevel.Warning, null, message, args);
        public static void LogError(string message, params object[] args) => Log(LogLevel.Error, null, message, args);
        public static void LogError(Exception ex, string message, params object[] args) => Log(LogLevel.Error, ex, message, args);

        private static string addPrefix(string message) => "[KCTR] " + message;
    }
}
