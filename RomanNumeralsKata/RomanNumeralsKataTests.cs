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

    public class NumberToRomanNumeralsMapper
    {
        public static NumberToRomanNumeralsMapper FromInteger(int input)
        {
            return new NumberToRomanNumeralsMapper();
        }

        public string AsRomanNumerals()
        {
            return "I";
        }
    }
}
