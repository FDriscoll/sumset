using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        public static List<List<int>> FindSetsThatSumToTotal(int sizeOfSet, int total, int largestValue)
        {
            if (sizeOfSet == 1 && total <= largestValue && total > 0)
            {
                List<List<int>> firstElement = new List<List<int>>();
                firstElement.Add(new List<int> { total });
                return firstElement;
            }
            else if (sizeOfSet == 1)
            {
                return null;
            }

            List<List<int>> listOfSets = null;

            for (int i = 1; i <= largestValue && i < total; i++)
            {
                List<List<int>> listOfSmallerSets = FindSetsThatSumToTotal(sizeOfSet - 1, total - i, i);

                if (listOfSmallerSets != null)
                {
                    if (listOfSets == null)
                    {
                        listOfSets = new List<List<int>>();
                    }

                    GrowSets(listOfSets, i, listOfSmallerSets);
                }
            }
            return listOfSets;
        }

        private static void GrowSets(List<List<int>> listOfSets, int i, List<List<int>> listOfSmallerSets)
        {
            foreach (List<int> smallSet in listOfSmallerSets)
            {
                List<int> bigSet = new List<int> { i };
                bigSet.AddRange(smallSet);
                listOfSets.Add(bigSet);
            }
        }

        public static string ConvertListToString(List<List<int>> listOfSets)
        {
            string listOfSetsString = null;

            foreach(var set in listOfSets)
            {
                foreach(int number in set)
                {
                    listOfSetsString = listOfSetsString + number.ToString() + ",";
                }

                listOfSetsString = listOfSetsString.TrimEnd(',') + "\n";
            }

            return listOfSetsString;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Size Of Set?");
            int sizeOfSet = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum to What?");
            int sum = Convert.ToInt32(Console.ReadLine());

            List<List<int>> listOfSets = FindSetsThatSumToTotal(sizeOfSet, sum, 9);

            if (listOfSets == null)
            {
                Console.WriteLine("No Such Sets");
            }
            else
            {
                Console.WriteLine("{0}", ConvertListToString(listOfSets));
            }
        }
    }
}
