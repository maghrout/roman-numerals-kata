using Xunit;

namespace RomanNumeralsKata
{
    public class RomanNumeralsKataTests
    {
        [Fact]
        public void Test1()
        {
            NumberToRomanNumeralsMapper numberToRomanNumeralsMapper = NumberToRomanNumeralsMapper.FromInteger(1);
            string result = numberToRomanNumeralsMapper.AsRomanNumerals();
            Assert.Equal("I", result);
        }
    }
}
