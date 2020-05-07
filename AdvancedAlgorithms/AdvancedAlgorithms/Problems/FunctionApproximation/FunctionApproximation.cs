using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Problems.FunctionApproximation
{
    public class FunctionApproximation
    {
        protected List<ValuePair> known_values;

        public FunctionApproximation()
        {
            this.known_values = new List<ValuePair>();
        }

        protected float Objective(List<float> coefficients)
        {
            float sum_diff = 0;
            foreach (var valuepair in known_values)
            {
                float x = valuepair.Input;
                float y = coefficients[0] * (float)Math.Pow(x - coefficients[1], 3) +
                          coefficients[2] * (float)Math.Pow(x - coefficients[3], 2) +
                          coefficients[4];
                float diff = (float)Math.Pow(y - valuepair.Output, 2);
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
                        ValuePair valuepair = new ValuePair(float.Parse(values[0]), float.Parse(values[0]));
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
