using ConsoleYoutubeDownloader.Internal;
using System;
using System.Text.RegularExpressions;

namespace ConsoleYoutubeDownloader
{
    public static partial class CSTestingElement
    {
        public static String testingURL = "https://www.youtube.com/watch?v=A4LiP8WFuG0";
        public static String ID;

        public static void Main(string[] args)
        {
            Console.WriteLine("Attempting to use REGEX to get video ID");
            FilterURL();
            Console.ReadLine();
        }

        public static void FilterURL()
        {
            Console.WriteLine("TODO : internal methods + isParsable");
            if(IsParsable(testingURL, out ID))
            {
                Console.WriteLine(ID);
            }
        }

        public static bool ValidateVideoId(this string videoId)
        {
            if (videoId.IsBlank())
                return false;

            if (videoId.Length != 11)
                return false;

            return !Regex.IsMatch(videoId, @"[^0-9a-zA-Z_\-]");
        }

        private static bool IsParsable(string videoUrl, out string videoId)
        {
            videoUrl = testingURL;
            videoId = default(string);

            if (videoUrl.IsBlank())
                return false;

            // https://www.youtube.com/watch?v=yIVRs6YSbOM
            var regularMatch =
                Regex.Match(videoUrl, @"youtube\..+?/watch.*?v=(.*?)(?:&|/|$)").Groups[1].Value;
            if (regularMatch.IsNotBlank() && ValidateVideoId(regularMatch))
            {
                videoId = regularMatch;
                return true;
            }

            // https://youtu.be/yIVRs6YSbOM
            var shortMatch =
                Regex.Match(videoUrl, @"youtu\.be/(.*?)(?:\?|&|/|$)").Groups[1].Value;
            if (shortMatch.IsNotBlank() && ValidateVideoId(shortMatch))
            {
                videoId = shortMatch;
                return true;
            }

            // https://www.youtube.com/embed/yIVRs6YSbOM
            var embedMatch =
                Regex.Match(videoUrl, @"youtube\..+?/embed/(.*?)(?:\?|&|/|$)").Groups[1].Value;
            if (embedMatch.IsNotBlank() && ValidateVideoId(embedMatch))
            {
                videoId = embedMatch;
                return true;
            }

            return false;
        }
    }
}
