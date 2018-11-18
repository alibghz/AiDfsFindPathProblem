using System;

namespace AiDfsFindPathProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = System.IO.Directory.GetCurrentDirectory();
                string[] lines = System.IO.File.ReadAllLines(path + @"\problem.txt");
                string result = string.Empty;
                Int32.TryParse(lines[0], out int count);
                if (count > 0)
                {
                    for (int i = 1; i <= count; i++)
                    {
                        try
                        {
                            Console.WriteLine(lines[i]);
                            var n = lines[i].Split(' ');
                            var start = new CellAddress(Int32.Parse(n[0]), Int32.Parse(n[1]));
                            var end = new CellAddress(Int32.Parse(n[2]), Int32.Parse(n[3]));
                            var problemSolver = new ProblemSolver(start, end);
                            result += $"{i}. {problemSolver.Solve()}\n";
                        }
                        catch (Exception e)
                        {
                            result += $"{i}. {e.Message}\n";
                        }
                    }
                }
                Console.Write(result);
                System.IO.File.WriteAllText(path + @"\solution.txt", result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
