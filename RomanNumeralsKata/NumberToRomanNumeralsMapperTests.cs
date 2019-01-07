using Xunit;

namespace RomanNumeralsKata
{
    public class NumberToRomanNumeralsMapperTests
    {
        [Theory]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
        [InlineData(8, "VIII")]
        [InlineData(9, "IX")]
        [InlineData(10, "X")]
        [InlineData(39, "XXXIX")]
        [InlineData(40, "XL")]
        [InlineData(49, "XLIX")]
        [InlineData(50, "L")]
        [InlineData(89, "LXXXIX")]
        [InlineData(90, "XC")]
        [InlineData(99, "XCIX")]
        [InlineData(100, "C")]
        [InlineData(399, "CCCXCIX")]
        [InlineData(400, "CD")]
        [InlineData(499, "CDXCIX")]
        [InlineData(500, "D")]
        [InlineData(899, "DCCCXCIX")]
        [InlineData(900, "CM")]
        [InlineData(999, "CMXCIX")]
        [InlineData(1000, "M")]
        [InlineData(3999, "MMMCMXCIX")]
        public void WhenANumberIsPassedIntoNumberToRomanNumeralsMapper_TheCorrectRomanNumeralsAreReturned(int numberInput, string expectedRomanNumerals)
        {
            NumberToRomanNumeralsMapper numberToRomanNumeralsMapper = NumberToRomanNumeralsMapper.FromInteger(numberInput);
            string result = numberToRomanNumeralsMapper.AsRomanNumerals();
            Assert.Equal(expectedRomanNumerals, result);
        }
    }
}
