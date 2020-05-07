using AdvancedAlgorithms.Algorithms;
using AdvancedAlgorithms.Problems.TravellingSalesman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Solutions
{
    class TravellingSalesmanNSGA
    {
        private TravellingSalesmanProblem problem;
        private NSGA solverAlgorithm;

        public TravellingSalesmanNSGA(TravellingSalesmanProblem problem, NSGA algorithm)
        {
            this.problem = problem;
            this.solverAlgorithm = algorithm;
            this.problem.LoadTownsFromFile("inputTowns.txt");
        }


    }
}
