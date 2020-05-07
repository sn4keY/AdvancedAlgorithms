using AdvancedAlgorithms.Problems.WorkAssignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Solutions
{
    class WorkAssignmentGenetic : WorkAssignmentProblem
    {
        public WorkAssignmentGenetic()
        {

        }

        public void Setup()
        {
            this.LoadFromFile("inputWorkassignment.txt");
        }
    }
}
