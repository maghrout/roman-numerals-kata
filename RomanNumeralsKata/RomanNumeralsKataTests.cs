using Xunit;

namespace RomanNumeralsKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RomanNumeralsKataTests
    {
        [Theory]
        [InlineData(1, "I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(4, "IV")]
        [InlineData(5, "V")]
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
            new RomanNumeral{Symbol = "V", Value = 5},
            new RomanNumeral{Symbol = "IV", Value = 4},
            new RomanNumeral{Symbol = "I", Value = 1},
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
                if (RomanNumerals.Any(x => x.TryModulus(input, out value, out input)))
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
        public int Value { get; set; }
        public string Symbol { get; set; }

        public bool TryModulus(int input, out string romanNumeral, out int remainder)
        {
            if (input % Value == 0)
            {
                romanNumeral = Symbol;
                remainder = input - Value;
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
