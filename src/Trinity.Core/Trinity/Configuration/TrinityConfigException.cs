using System;

namespace Trinity.Configuration
{
    /// <summary>
    /// Represents configuration IO exceptions.
    /// </summary>
    public class TrinityConfigException : Exception
    {
        internal TrinityConfigException(string message) : base(message) { }
        internal TrinityConfigException(string message, Exception innerException) : base(message, innerException) { }
    }
}
