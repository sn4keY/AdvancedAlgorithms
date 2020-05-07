using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Problems.FunctionApproximation
{
    public class FunctionApproximationProblem
    {
        protected List<ValuePair> known_values;

        public FunctionApproximationProblem()
        {
            this.known_values = new List<ValuePair>();
        }

        protected double Objective(List<double> coefficients)
        {
            double sum_diff = 0;
            foreach (var valuepair in known_values)
            {
                double x = valuepair.Input;
                double y = coefficients[0] * Math.Pow(x - coefficients[1], 3) +
                          coefficients[2] * Math.Pow(x - coefficients[3], 2) +
                          coefficients[4];
                double diff = Math.Pow(y - valuepair.Output, 2);
                sum_diff += diff;
            }
            return sum_diff;
        }

        public void LoadKnownValuesFromFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] values = sr.ReadLine().Split('\t');
                        string elso = values[0].Replace('.', ',');
                        string masodik = values[1].Replace('.', ',');
                        double egyik = double.Parse(elso);
                        double masik = double.Parse(masodik);
                        ValuePair valuepair = new ValuePair(egyik, masik);
                        this.known_values.Add(valuepair);
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
