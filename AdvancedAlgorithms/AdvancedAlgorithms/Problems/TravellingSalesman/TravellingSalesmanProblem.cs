using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedAlgorithms.Problems.TravellingSalesman
{
    public class TravellingSalesmanProblem
    {
        protected List<Town> towns;

        public TravellingSalesmanProblem()
        {
            this.towns = new List<Town>();
        }

        protected float Objective(List<Town> route)
        {
            float sum_length = 0;
            for (int ti = 0; ti < route.Count - 1; ti++)
            {
                Town t1 = route[ti];
                Town t2 = route[ti + 1];
                sum_length += (float)Math.Sqrt(Math.Pow(t1.X - t2.X, 2) + Math.Pow(t1.Y - t2.Y, 2));
            }
            return sum_length;
        }

        public void LoadTownsFromFile(string filename)
        {
            try
            {   
                using (StreamReader sr = new StreamReader(filename))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] coordinates = sr.ReadLine().Split('\t');
                        Town town = new Town(float.Parse(coordinates[0]), float.Parse(coordinates[0]));
                        this.towns.Add(town);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void SaveTownsToFile(string filename, List<Town> townsList)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (var town in townsList)
                    {
                        sw.WriteLine(town.X + '\t' + town.Y);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be written:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
