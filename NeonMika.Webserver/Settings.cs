﻿
namespace NeonMika.Webserver
{
    /// <summary>
    /// Static settings for the webserver
    /// </summary>
    static class Settings
    {
        /// <summary>
        /// Maximum byte size for a HTTP request sent to the server
        /// POST packages will get split up into smaller packages this size
        /// </summary>
        public const int MAX_REQUESTSIZE = 1028;

        /// <summary>
        /// Buffersize for response file sending 
        /// </summary>
        public const int FILE_BUFFERSIZE = 512;

        /// <summary>
        /// Path to save POST arguments temporarly
        /// </summary>
        public const string FIRMWARE_PATH = "\\SD\\";

        public const string POST_TEMP_FILENAME = "tpm.tmp";
        
        public const string SERVER_VERSION = "1.2";
    }
}
