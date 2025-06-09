using System;
using Xunit;

namespace SmartTimeSpanParser.Tests
{
    public class SmartTimeSpanTests
    {
        [Theory]
        [InlineData("2h", 2, 0, 0)]
        [InlineData("1.5 days", 36, 0, 0)] // 1.5 days = 36 hours
        [InlineData("45 minutes", 0, 45, 0)]
        [InlineData("30s", 0, 0, 30)]
        [InlineData("1h 30m", 1, 30, 0)]
        [InlineData("2d 3h", 51, 0, 0)] // 2 days = 48 hours + 3 = 51 hours
        public void Parse_ValidInput_ReturnsExpectedTimeSpan(string input, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var expected = new TimeSpan(expectedHours, expectedMinutes, expectedSeconds);
            var actual = SmartTimeSpan.Parse(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("invalid")]
        public void Parse_InvalidInput_ThrowsFormatException(string input)
        {
            Assert.ThrowsAny<Exception>(() => SmartTimeSpan.Parse(input));
        }

        [Fact]
        public void TryParse_ValidInput_ReturnsTrue()
        {
            var success = SmartTimeSpan.TryParse("1h 15m", out var result);
            Assert.True(success);
            Assert.Equal(new TimeSpan(1, 15, 0), result);
        }

        [Fact]
        public void TryParse_InvalidInput_ReturnsFalse()
        {
            var success = SmartTimeSpan.TryParse("invalid", out var result);
            Assert.False(success);
            Assert.Equal(default, result);
        }
    }
}
