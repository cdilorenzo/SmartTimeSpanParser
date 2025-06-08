using System.Globalization;
using System.Text.RegularExpressions;

namespace SmartTimeSpanParser
{
    public static class SmartTimeSpan
    {
        public static TimeSpan Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input cannot be null or whitespace.", nameof(input));

            input = input.Trim().ToLowerInvariant();
            var pattern = @"(?<value>\d+(\.\d+)?)(\s*)(?<unit>days?|d|hours?|h|minutes?|m|seconds?|s)";
            var matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
                throw new FormatException($"Invalid time span format: '{input}'");

            double totalSeconds = 0;

            foreach (Match match in matches)
            {
                var value = double.Parse(match.Groups["value"].Value, CultureInfo.InvariantCulture);
                var unit = match.Groups["unit"].Value;

                totalSeconds += unit switch
                {
                    "d" or "day" or "days" => value * 86400,
                    "h" or "hour" or "hours" => value * 3600,
                    "m" or "minute" or "minutes" => value * 60,
                    "s" or "second" or "seconds" => value,
                    _ => throw new FormatException($"Unknown time unit: '{unit}'")
                };
            }

            return TimeSpan.FromSeconds(totalSeconds);
        }

        public static bool TryParse(string input, out TimeSpan result)
        {
            try
            {
                result = Parse(input);
                return true;
            }
            catch
            {
                result = default;
                return false;
            }
        }
    }
}
