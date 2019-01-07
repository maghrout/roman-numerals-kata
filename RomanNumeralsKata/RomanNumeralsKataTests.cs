using Xunit;

namespace RomanNumeralsKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RomanNumeralsKataTests
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

    public class NumberToRomanNumeralsMapper
    {
        private static readonly List<RomanNumeral> RomanNumerals = new List<RomanNumeral>
        {
            new RomanNumeral("M", 1000),
            new RomanNumeral("CM", 900),
            new RomanNumeral("D", 500),
            new RomanNumeral("CD", 400),
            new RomanNumeral("C", 100),
            new RomanNumeral("XC", 90),
            new RomanNumeral("L", 50),
            new RomanNumeral("XL", 40),
            new RomanNumeral("X", 10),
            new RomanNumeral("IX", 9),
            new RomanNumeral("V", 5),
            new RomanNumeral("IV", 4),
            new RomanNumeral("I", 1),
        };

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
                string value = "";
                if (RomanNumerals.Any(x => x.TryDivide(input, out value, out input)))
                {
                    romanNumeralString += value;
                }
                else
                {
                    throw new ArgumentException("Not a valid number");
                }
            }

            return new NumberToRomanNumeralsMapper(romanNumeralString);
        }

        public string AsRomanNumerals()
        {
            return _romanNumeralString;
        }
    }

    public class RomanNumeral
    {
        private readonly string _symbol;
        private readonly int _value;

        public RomanNumeral(string symbol, int value)
        {
            _symbol = symbol;
            _value = value;
        }

        public bool TryDivide(int input, out string romanNumeral, out int remainder)
        {
            if (input / _value >= 1)
            {
                romanNumeral = _symbol;
                remainder = input - _value;
                return true;
            }
            else
            {
                romanNumeral = "";
                remainder = input;
                return false;
            }
        }
    }
}
