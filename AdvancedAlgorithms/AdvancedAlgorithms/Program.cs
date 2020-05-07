using AdvancedAlgorithms.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            FuncApproxHillClimbStochastic(100, 0, 60);
        }

        static void FuncApproxHillClimbStochastic(int epsilon, double requiredFitness, double maxTime)
        {
            FunctionApproximationHillClimbStochastic fahcs = new FunctionApproximationHillClimbStochastic(epsilon, requiredFitness, maxTime);
            //List<double> solution = fahcs.Run();
            List<double> solution = fahcs.RunWithInfo();
            List<double> start = fahcs.GetStartingElements();
            Console.WriteLine($"Finished! \n Time elapsed: {fahcs.GetElapsedTime()} \n Fitness: {fahcs.GetFitness()}");
            Console.WriteLine($" Starting coefficients: {start[0]}, {start[1]}, {start[2]}, {start[3]}, {start[4]}");
            Console.WriteLine($" Coefficients: {solution[0]}, {solution[1]}, {solution[2]}, {solution[3]}, {solution[4]}");
            Console.ReadLine();
        }
    }
}
