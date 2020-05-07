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
            FuncApproxHillClimbStochastic(5, 0, 60);
        }

        static void FuncApproxHillClimbStochastic(int epsilon, double requiredFitness, double maxTime)
        {
            FunctionApproximationHillClimbStochastic fahcs = new FunctionApproximationHillClimbStochastic(epsilon, requiredFitness, maxTime);
            List<double> solution = fahcs.Run();
            Console.WriteLine($"Finished! \n Time elapsed: {fahcs.GetElapsedTime()} \n Fitness: {fahcs.GetFitness()}");
            Console.WriteLine($" Coefficients: {solution[0]}, {solution[1]}, {solution[2]}, {solution[3]}, {solution[4]}");
            Console.ReadLine();
        }
    }
}
