namespace AOTC_2024
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> input = File.ReadAllLines("Input/Day3.txt").ToList();
            string fullText = string.Concat(File.ReadAllLines("Input/Day3.txt"));
            Console.WriteLine("Your answer is: " + ProblemSolver.Day3Part2(fullText.ToLower()));
            Console.ReadLine();
        }
    }
}
