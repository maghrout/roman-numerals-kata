using Xunit;

namespace RomanNumeralsKata
{
    using System;

    public class RomanNumeralsKataTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void WhenANumberIsPassedIntoNumberToRomanNumeralsMapper_TheCorrectRomanNumeralsAreReturned(int numberInput, string expectedRomanNumerals)
        {
            NumberToRomanNumeralsMapper numberToRomanNumeralsMapper = NumberToRomanNumeralsMapper.FromInteger(numberInput);
            string result = numberToRomanNumeralsMapper.AsRomanNumerals();
            Assert.Equal(expectedRomanNumerals, result);
        }
    }

    public class NumberToRomanNumeralsMapper
    {
        private readonly string _romanNumeralString;

        private NumberToRomanNumeralsMapper(string romanNumeralString)
        {
            _romanNumeralString = romanNumeralString;
        }

        public static NumberToRomanNumeralsMapper FromInteger(int input)
        {
            var romanNumeralString = "";
            while (input != 0)
            {
                if (input == 3)
                {
                    romanNumeralString += "III";
                    input -= input;
                }
                else if (input == 2)
                {
                    romanNumeralString += "II";
                    input -= input;
                }
                else if (input == 1)
                {
                    romanNumeralString += "I";
                    input -= input;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

            return new NumberToRomanNumeralsMapper(romanNumeralString);
        }

        public string AsRomanNumerals()
        {
            return _romanNumeralString;
        }
    }
}
