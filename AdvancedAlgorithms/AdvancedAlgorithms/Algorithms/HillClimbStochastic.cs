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
        public double currentFitness;
        public Func<HillClimbStochastic<T>, bool> StopCondition;
        public double elapsedTime;

        private int indexInSearchSpace;

        public HillClimbStochastic(List<T> searchSpace, int epsilon, Func<T, double> Fitness, Func<HillClimbStochastic<T>, bool> StopCondition)
        {
            this.searchSpace = searchSpace;
            this.epsilon = epsilon;
            this.Fitness = Fitness;
            this.StopCondition = StopCondition;
        }

        public T RunAlgorithm()
        {
            sw.Reset();
            sw.Start();
            this.indexInSearchSpace = rnd.Next(0, searchSpace.Count + 1);
            this.currentSolution = searchSpace[this.indexInSearchSpace];
            this.currentFitness = this.Fitness(this.currentSolution);
            while (!StopCondition(this))
            {
                T temp = GetRandomElementWithinEpsilon();
                double tempFitness = this.Fitness(temp);
                if (tempFitness <= this.currentFitness)
                {
                    this.currentSolution = temp;
                }
                this.elapsedTime = sw.Elapsed.TotalSeconds;
            }
            sw.Stop();
            return currentSolution;
        }

        private T GetRandomElementWithinEpsilon()
        {
            if (this.indexInSearchSpace + epsilon >= this.searchSpace.Count - 1)
            {
                this.indexInSearchSpace = rnd.Next(this.indexInSearchSpace - this.epsilon, this.searchSpace.Count);
            }
            else if (this.indexInSearchSpace - epsilon <= 0)
            {
                this.indexInSearchSpace = rnd.Next(0, this.indexInSearchSpace + this.epsilon + 1);
            }
            else
            {
                this.indexInSearchSpace = rnd.Next(this.indexInSearchSpace - this.epsilon, this.indexInSearchSpace + this.epsilon + 1);
            }
            return searchSpace[this.indexInSearchSpace];
        }
    }
}
