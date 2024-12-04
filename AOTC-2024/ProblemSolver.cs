using AOTC_2024.Models;

namespace AOTC_2024
{
    public static class ProblemSolver
    {
        public static int Day1Part1(List<string> input)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int totalDistance = 0;

            foreach (var row in input)
            {
                left.Add(int.Parse(row.Split("   ")[0]));
                right.Add(int.Parse(row.Split("   ")[1]));
            }

            while (left.Count > 0)
            {
                var lowestLeft = left.Min(c => c);
                var lowestRight = right.Min(c => c);

                totalDistance += (lowestLeft >= lowestRight) ? lowestLeft - lowestRight : lowestRight - lowestLeft;

                left.Remove(lowestLeft);
                right.Remove(lowestRight);
            }

            return totalDistance;
        }

        public static int Day1Part2(List<string> input)
        {
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int similarityScore = 0;

            foreach (var row in input)
            {
                left.Add(int.Parse(row.Split("   ")[0]));
                right.Add(int.Parse(row.Split("   ")[1]));
            }

            for (int i = 0; i < left.Count; ++i)
            {
                var count = right.FindAll(c => c == left[i]).Count();
                if (count != 0) similarityScore += (left[i] * count);
            }

            return similarityScore;
        }

        public static int Day2Part1(List<string> input)
        {
            int safeCount = 0, unsafeCount = 0;

            foreach (var row in input)
            {
                string[] values = row.Split(' ');
                int previousValue = -1;
                bool shouldContinue = true;
                string currentDirection = string.Empty;

                for (int i = 0; i < values.Count(); ++i)
                {
                    int currentValue = int.Parse(values[i]);
                    int difference = 0;

                    if (previousValue != -1)
                    {
                        if (previousValue >= currentValue)
                        {
                            difference = previousValue - currentValue;
                            if (!string.IsNullOrEmpty(currentDirection) && currentDirection != "Subtraction")
                            {
                                unsafeCount++;
                                break;
                            }
                            currentDirection = "Subtraction";
                        }
                        else
                        {
                            difference = currentValue - previousValue;
                            if (!string.IsNullOrEmpty(currentDirection) && currentDirection != "Addition")
                            {
                                unsafeCount++;
                                break;
                            }
                            currentDirection = "Addition";
                        }

                        if (difference > 3 || difference < 1) shouldContinue = false;
                        else if (i == values.Count() - 1)
                            safeCount++;

                        previousValue = currentValue;
                    }
                    else
                        previousValue = currentValue;

                    if (!shouldContinue)
                    {
                        unsafeCount++;
                        break;
                    }
                }
            }
            return safeCount;
        }

        public static int Day2Part2(List<string> input)
        {
            int safeCount = 0, unsafeCount = 0;

            foreach (var row in input)
            {
                string[] values = row.Split(' ');
                bool isSafe = Utility.ReportIsSafe(values.ToList());

                if (isSafe) safeCount++;
                else unsafeCount++;
            }
            return safeCount;
        }

        public static int Day3Part1(string input)
        {
            List<int> mulLocations = input.AllIndexesOf("mul(");
            List<string> potentialTokens = new List<string>();

            foreach (int m in mulLocations)
            {
                string tempToken = string.Empty;
                for (int i = m; i < input.Length; ++i)
                {
                    tempToken += input[i];

                    if (input[i] == ')')
                    {
                        potentialTokens.Add(tempToken);
                        break;
                    }
                }
            }

            return Day3Token.GetAllToken(potentialTokens).Where(t => t.IsValid).Sum(a => a.Result);
        }

        public static int Day3Part2(string input)
        {
            List<int> doLocations = input.AllIndexesOf("do()");
            List<int> dontLocations = input.AllIndexesOf("don't()");
            List<int> mulLocations = input.AllIndexesOf("mul(");
            List<string> potentialTokens = new List<string>();
            List<Day3Token> tokens = new List<Day3Token>();

            foreach (int m in mulLocations)
            {
                bool shouldEnable = true;
                int recentDo = -1;
                int recentDont = -1;

                if (doLocations.Any(f => f < m)) recentDo = doLocations.Where(f => f < m).Max();
                if (dontLocations.Any(f => f < m)) recentDont = dontLocations.Where(f => f < m).Max();

                if (recentDo != -1 || recentDont != -1)
                {
                    if (recentDo > recentDont)
                        shouldEnable = true;
                    else if (recentDont > recentDo)
                        shouldEnable = false;
                }

                string tempToken = string.Empty;
                for (int i = m; i < input.Length; ++i)
                {
                    tempToken += input[i];

                    if (input[i] == ')')
                    {
                        tokens.Add(new Day3Token(tempToken, shouldEnable));
                        break;
                    }
                }
            }
            return tokens.Where(t => t.IsValid && t.Enabled).Sum(a => a.Result);
        }
    }
}
