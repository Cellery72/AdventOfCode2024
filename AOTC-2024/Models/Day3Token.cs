namespace AOTC_2024.Models
{
    public class Day3Token
    {
        public int Result => _FirstValue != null && _SecondValue != null ? _FirstValue.Value * _SecondValue.Value : -1;
        public bool IsValid => _IsValid;
        public bool Enabled => _Enabled;

        private int? _FirstValue;
        private int? _SecondValue;
        private string _FullToken;
        private bool _IsValid;
        private bool _Enabled;

        public Day3Token(string text, bool shouldEnable = true)
        {
            _Enabled = shouldEnable;
            _FullToken = text;
            _IsValid = false;
            string tempToken = string.Empty;

            if (text.StartsWith("mul("))
            {
                tempToken = text.Substring(4, text.Length - 5);
                try
                {
                    var values = tempToken.Split(',');
                    if (values.Length == 2)
                    {
                        _FirstValue = int.Parse(values[0]);
                        _SecondValue = int.Parse(values[1]);
                        _IsValid = true;
                    }
                    else
                        throw new Exception("Too many values");
                }
                catch { }
            }
        }

        public static List<Day3Token> GetAllToken(List<string> potentialTokens)
        {
            List<Day3Token> tokens = new List<Day3Token>();

            foreach (string t in potentialTokens)
                tokens.Add(new Day3Token(t));

            return tokens;
        }
    }
}
