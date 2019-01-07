namespace RomanNumeralsKata
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
}