using Xunit;

namespace RomanNumeralsKata
{
    using System;

    public class RomanNumeralsKataTests
    {
        [Fact]
        public void ParsesNumber1Correctly()
        {
            NumberToRomanNumeralsMapper numberToRomanNumeralsMapper = NumberToRomanNumeralsMapper.FromInteger(1);
            string result = numberToRomanNumeralsMapper.AsRomanNumerals();
            Assert.Equal("I", result);
        }

        [Fact]
        public void ParsesNumber2Correctly()
        {
            NumberToRomanNumeralsMapper numberToRomanNumeralsMapper = NumberToRomanNumeralsMapper.FromInteger(2);
            string result = numberToRomanNumeralsMapper.AsRomanNumerals();
            Assert.Equal("II", result);
        }
    }

    public class NumberToRomanNumeralsMapper
    {
        private string _romanNumeralString;

        private NumberToRomanNumeralsMapper(string romanNumeralString)
        {
            _romanNumeralString = romanNumeralString;
        }

        public static NumberToRomanNumeralsMapper FromInteger(int input)
        {
            var romanNumeralString = "";
            while (input != 0)
            {
                if (input == 2)
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
