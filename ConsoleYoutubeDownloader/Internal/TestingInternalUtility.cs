using System;

namespace ConsoleYoutubeDownloader.Internal
{
    internal static class TestingInternalUtility
    {
        public static bool IsBlank(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotBlank(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }



    }
}