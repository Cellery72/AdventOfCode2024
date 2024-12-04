namespace AOTC_2024
{
    public static class Utility
    {
        public static bool ReportIsSafe(List<string> values)
        {
            int previousValue = -1;
            string direction = string.Empty;
            List<int> results = new List<int>();

            for (int i = 0; i < values.Count; ++i)
            {
                int currentValue = int.Parse(values[i]);
                int difference = 0;

                if (previousValue != -1)
                {
                    if (previousValue == currentValue)
                        difference = 0;
                    else if (previousValue > currentValue)
                    {
                        difference = previousValue - currentValue;
                        if (!string.IsNullOrEmpty(direction) && direction != "Subtraction")
                        {
                            results.Add(-1);
                            previousValue = currentValue;
                            continue;
                        }
                        direction = "Subtraction";
                    }
                    else
                    {
                        difference = currentValue - previousValue;
                        if (!string.IsNullOrEmpty(direction) && direction != "Addition")
                        {
                            results.Add(-1);
                            previousValue = currentValue;
                            continue;
                        }
                        direction = "Addition";
                    }

                    if (difference > 3 || difference < 1)
                        results.Add(-1);
                    else
                        results.Add(difference);

                    previousValue = currentValue;
                }
                else
                {
                    previousValue = currentValue;
                    results.Add(1);
                }
            }

            var anyInvalid = results.Where(f => f == -1).Count();

            if (anyInvalid <= 1)
                return true;
            else
                return false;
        }
    }

    public static class StringExtensions
    {
        public static List<int> AllIndexesOf(this string str, string value)
        {
            List<int> indexes = new List<int>();
            for (int index = 0;;index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
