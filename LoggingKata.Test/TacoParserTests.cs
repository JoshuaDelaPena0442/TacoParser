using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            var tacoParser = new TacoParser();
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("33.470013,-86.816966,Taco Bell Birmingham...", -86.816966)]
        [InlineData("34.8831,-84.293899,Taco Bell Blue Ridg...", -84.293899)]
        [InlineData("34.201107,-86.151229,Taco Bell Boa...", -86.151229)]
        [InlineData("34.095209,-84.011894,Taco Bell Bufor...", -84.011894)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();
            var actual = tacoParserInstance.Parse(line);
            Assert.Equal(expected, actual.Location.Longitude);
        }

        [Theory]
        [InlineData("34.018008,-86.079099,Taco Bell Attall...", 34.018008)]
        [InlineData("32.555148,-84.946447,Taco Bell Columbus/1...", 32.555148)]
        [InlineData("32.425341,-84.948505,Taco Bell Columbus/1...", 32.425341)]
        [InlineData("32.484926,-84.935962,Taco Bell Columbus...", 32.484926)]
        [InlineData("33.648244,-84.011856,Taco Bell Conyers...", 33.648244)]

        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoParserInstance = new TacoParser();
            var actual = tacoParserInstance.Parse(line);
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
