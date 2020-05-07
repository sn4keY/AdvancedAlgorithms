using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Algorithms
{
    class HillClimbStochastic<T>
    {
        private static Random rnd = new Random();
        private static Stopwatch sw = new Stopwatch();

        public List<T> searchSpace;
        public T currentSolution;
        public int epsilon;
        public Func<T, double> Fitness;
        public Func<HillClimbStochastic<T>, bool> StopCondition;

        // For measuring
        public double currentFitness;
        public double elapsedTime;
        public int iterations;
        public T startElement;

        private int indexInSearchSpace;

        public HillClimbStochastic(List<T> searchSpace, int epsilon, Func<T, double> Fitness, Func<HillClimbStochastic<T>, bool> StopCondition)
        {
            this.searchSpace = searchSpace;
            this.epsilon = epsilon;
            this.Fitness = Fitness;
            this.StopCondition = StopCondition;
            this.iterations = 0;
        }

        public T RunAlgorithm()
        {
            sw.Reset();
            sw.Start();
            this.indexInSearchSpace = rnd.Next(0, searchSpace.Count + 1);//Utilities.Utilities.GetRandomInt(0, searchSpace.Count + 1);//rnd.Next(0, searchSpace.Count + 1);
            this.currentSolution = searchSpace[this.indexInSearchSpace];
            this.currentFitness = this.Fitness(this.currentSolution);
            this.startElement = currentSolution;
            while (!StopCondition(this))
            {
                T temp = GetRandomElementWithinEpsilon();
                double tempFitness = this.Fitness(temp);
                if (tempFitness <= this.currentFitness)
                {
                    this.currentSolution = temp;
                    this.currentFitness = tempFitness;
                }
                this.elapsedTime = sw.Elapsed.TotalSeconds;
                iterations++;
            }
            sw.Stop();
            return currentSolution;
        }

        public T RunAlgorithmWithInfo()
        {
            sw.Reset();
            sw.Start();
            this.indexInSearchSpace = rnd.Next(0, searchSpace.Count + 1);
            this.currentSolution = searchSpace[this.indexInSearchSpace];
            this.currentFitness = this.Fitness(this.currentSolution);
            this.startElement = currentSolution;
            while (!StopCondition(this))
            {
                T temp = GetRandomElementWithinEpsilon();
                double tempFitness = this.Fitness(temp);
                if (tempFitness <= this.currentFitness)
                {
                    this.currentSolution = temp;
                    this.currentFitness = tempFitness;
                }
                this.elapsedTime = sw.Elapsed.TotalSeconds;
                iterations++;
                if (iterations%100000 == 0)
                {
                    this.WriteInfo();
                }
            }
            sw.Stop();
            return currentSolution;
        }

        private T GetRandomElementWithinEpsilon()
        {
            if (this.indexInSearchSpace + epsilon >= this.searchSpace.Count - 1)
            {
                this.indexInSearchSpace = rnd.Next(this.indexInSearchSpace - this.epsilon, this.searchSpace.Count);//Utilities.Utilities.GetRandomInt(this.indexInSearchSpace - this.epsilon, this.searchSpace.Count);//rnd.Next(this.indexInSearchSpace - this.epsilon, this.searchSpace.Count);
            }
            else if (this.indexInSearchSpace - epsilon <= 0)
            {
                this.indexInSearchSpace = rnd.Next(0, this.indexInSearchSpace + this.epsilon + 1);//Utilities.Utilities.GetRandomInt(0, this.indexInSearchSpace + this.epsilon + 1);//rnd.Next(0, this.indexInSearchSpace + this.epsilon + 1);
            }
            else
            {
                this.indexInSearchSpace = rnd.Next(this.indexInSearchSpace - this.epsilon, this.indexInSearchSpace + this.epsilon + 1);//Utilities.Utilities.GetRandomInt(this.indexInSearchSpace - this.epsilon, this.indexInSearchSpace + this.epsilon + 1);//rnd.Next(this.indexInSearchSpace - this.epsilon, this.indexInSearchSpace + this.epsilon + 1);
            }
            return searchSpace[this.indexInSearchSpace];
        }

        private void WriteInfo()
        {
            Console.Clear();
            Console.WriteLine("HillClimbStochastic running.");
            Console.WriteLine($" Number of iterations: {iterations}");
            Console.WriteLine($" Current fitness: {currentFitness}");
            Console.WriteLine($" Time elapsed: {elapsedTime}");
            Console.WriteLine($" Current index: {indexInSearchSpace}");
            List<double> list = currentSolution as List<double>;
            Console.WriteLine($" Coefficients: {list[0]}, {list[1]}, {list[2]}, {list[3]}, {list[4]}");
        }
    }
}
