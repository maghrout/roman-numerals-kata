namespace RomanNumeralsKata
{
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