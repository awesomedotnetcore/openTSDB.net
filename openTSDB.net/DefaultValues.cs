﻿namespace openTSDB.net
{
    internal sealed class DefaultValues
    {

        internal sealed class Tags
        {
            public const string HOST = "host";
        }

        internal sealed class Messages
        {
            public const string HOST_NAME_INVALID_ERROR_MESSAGE = "The host name can not be null or empty";
            public const string TAG_NAME_INVALID = "The TAG name can not be null or empty";
            public const string TAG_VALUE_INVALID = "Then TAG value ca n not be null or empty";
        }

        public const string UNKWNOWN = "unknown";
    }
}