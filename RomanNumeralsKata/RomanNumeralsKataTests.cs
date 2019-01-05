using Xunit;

namespace RomanNumeralsKata
{
    using System;
    using System.Collections.Generic;

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
        private static readonly List<RomanNumeral> RomanNumerals = new List<RomanNumeral>
        {
            new RomanNumeral{Symbol = "I", Value = 1},
            new RomanNumeral{Symbol = "II",Value = 2},
            new RomanNumeral{Symbol = "III",Value = 3},
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
                foreach (var romanNumeral in RomanNumerals)
                {
                    if (input == romanNumeral.Value)
                    {
                        romanNumeralString += romanNumeral.Symbol;
                        input -= romanNumeral.Value;
                    }
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
    }
}
