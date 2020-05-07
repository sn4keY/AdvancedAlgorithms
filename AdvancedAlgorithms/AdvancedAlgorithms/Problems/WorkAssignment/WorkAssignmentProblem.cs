using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Problems.WorkAssignment
{
    public class WorkAssignmentProblem
    {
        protected List<Person> persons;
        protected int requested_time;

        public WorkAssignmentProblem()
        {
            this.persons = new List<Person>();
        }

        protected float SumSalary(List<int> solution)
        {
            float sum = 0;
            int i = 0;
            foreach (var item in solution)
            {
                sum += item * persons[i].Salary;
                i++;
            }
            return sum;
        }

        protected float AvgQuality(List<int> solution)
        {
            float sum = 0;
            int i = 0;
            foreach (var item in solution)
            {
                sum += item * persons[i].Quality;
                i++;
            }
            return sum;
        }

        public virtual void LoadFromFile(string filename)
        {
            try
            {
                int i = 0;
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        if (i == 0)
                        {
                            this.requested_time = int.Parse(sr.ReadLine());
                        }
                        while (!sr.EndOfStream)
                        {
                            string[] qualities = sr.ReadLine().Split('\t');
                            Person person = new Person(float.Parse(qualities[0]), float.Parse(qualities[0]));
                            this.persons.Add(person);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
