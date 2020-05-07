using AdvancedAlgorithms.Algorithms;
using AdvancedAlgorithms.Problems.FunctionApproximation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Solutions
{
    class FunctionApproximationHillClimbStochastic : FunctionApproximationProblem
    {
        private HillClimbStochastic<List<double>> solver;
        private double requiredFitness;
        private double maxTime;

        public FunctionApproximationHillClimbStochastic(int epsilon, double requiredFitness, double maxTime)
        {
            this.LoadKnownValuesFromFile("inputValuePairs.txt");
            this.requiredFitness = requiredFitness;
            this.maxTime = maxTime;
            this.solver = new HillClimbStochastic<List<double>>(this.InitializeSearchSpace(), epsilon, this.Objective, this.StopCondition);
        }

        public List<double> Run()
        {
            return this.solver.RunAlgorithm();
        }

        public double GetFitness()
        {
            return this.solver.currentFitness;
        }

        public double GetElapsedTime()
        {
            return this.solver.elapsedTime;
        }

        private List<List<double>> InitializeSearchSpace()
        {
            List<List<double>> searchSpace = new List<List<double>>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 10; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            for (int m = 0; m < 10; m++)
                            {
                                searchSpace.Add(new List<double>() { i * 0.5, j * 0.5, k * 0.5, l * 0.5, m * 0.5 });
                            }
                        }
                    }
                }
            }
            return searchSpace;
        }

        private bool StopCondition(HillClimbStochastic<List<double>> solver)
        {
            return solver.currentFitness <= requiredFitness || maxTime <= solver.elapsedTime;
        }
    }
}
