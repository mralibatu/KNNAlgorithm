using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNNalgorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = 5;

            double[][] data = GetData();
            double[] item = { 0.62, 0.35 };
            Console.WriteLine(FindNearestIndex(item, data, k));

            Console.ReadLine();
        }

        public static int FindNearestIndex(double[] item, double[][] data, int k)
        {
            double[] distance = new double[data.Length];

            for (int i = 0; i < data.Length; i++)           //Find all the distance and fill the distance arr
            {
                distance[i] = DistanceFunc(item, data[i]);
            }
            Console.WriteLine("Distance : ");
            PrintArrTest(distance);

            double[] ordered = new double[distance.Length];
            Array.Copy(distance, ordered, distance.Length);
            double temp;
            int[] nearestValuesIndex = new int[ordered.Length];

            for (int i = 0; i < ordered.Length - 1; i++)        //Order all distances
            {
                for (int j = i + 1; j < ordered.Length; j++)
                {
                    if (ordered[i] > ordered[j])
                    {
                        temp = ordered[i];
                        ordered[i] = ordered[j];
                        ordered[j] = temp;
                    }
                }
            }
            Console.WriteLine("Ordered : ");
            PrintArrTest(ordered);


            for (int i = 0; i < ordered.Length; i++)        //find the ordered distances' index
            {
                for (int j = 0; j < ordered.Length; j++)
                {
                    if (ordered[i] == distance[j])
                    {
                        nearestValuesIndex[i] = j;
                    }
                }
            }

            Console.WriteLine("Nearest Values Index : ");
            PrintArrTest(nearestValuesIndex);
            int[] bestNearest = new int[k];
            for (int i = 0; i < k; i++)                 //collect best k element
            {
                bestNearest[i] = nearestValuesIndex[i];
            }

            Console.WriteLine("Best nearest indexes: ");
            PrintArrTest(bestNearest);

            int[] classes = new int[k];

            for (int i = 0; i < k; i++)                 //find classes
            {
                double[] dataTemp = data[bestNearest[i]];
                classes[i] = (int)dataTemp[3];
            }

            Console.WriteLine("Best nearest's classes : ");
            PrintArrTest(classes);

            int MaxCounterOfClassFinder = 0;            //find most frequent class
            int tempOfClassFinder = int.MinValue;
            for (int i = 0; i < classes.Length; i++)
            {
                int counter = 0;
                for (int j = 0; j < classes.Length; j++)
                {
                    if (classes[i] == classes[j])
                    {
                        counter++;
                    }
                }

                if (counter > MaxCounterOfClassFinder)
                {
                    MaxCounterOfClassFinder = counter;
                    tempOfClassFinder = classes[i];
                }
            }

            Console.WriteLine("Class of this item : ");
            return tempOfClassFinder;
        }
        static double[][] GetData()
        {
            double[][] data = new double[30][];
            data[0] = new double[] { 0, 0.32, 0.43, 0 };
            data[1] = new double[] { 1, 0.26, 0.54, 0 };
            data[2] = new double[] { 2, 0.27, 0.6, 0 };
            data[3] = new double[] { 3, 0.37, 0.36, 0 };
            data[4] = new double[] { 4, 0.37, 0.68, 0 };
            data[5] = new double[] { 5, 0.49, 0.32, 0 };
            data[6] = new double[] { 6, 0.46, 0.7, 0 };
            data[7] = new double[] { 7, 0.55, 0.32, 0 };
            data[8] = new double[] { 8, 0.57, 0.71, 0 };
            data[9] = new double[] { 9, 0.61, 0.42, 0 };
            data[10] = new double[] { 10, 0.63, 0.51, 0 };
            data[11] = new double[] { 11, 0.62, 0.63, 0 };
            data[12] = new double[] { 12, 0.39, 0.43, 1 };
            data[13] = new double[] { 13, 0.35, 0.51, 1 };
            data[14] = new double[] { 14, 0.39, 0.63, 1 };
            data[15] = new double[] { 15, 0.47, 0.4, 1 };
            data[16] = new double[] { 16, 0.48, 0.5, 1 };
            data[17] = new double[] { 17, 0.45, 0.61, 1 };
            data[18] = new double[] { 18, 0.55, 0.41, 1 };
            data[19] = new double[] { 19, 0.57, 0.53, 1 };
            data[20] = new double[] { 20, 0.56, 0.62, 1 };
            data[21] = new double[] { 21, 0.28, 0.12, 1 };
            data[22] = new double[] { 22, 0.31, 0.24, 1 };
            data[23] = new double[] { 23, 0.22, 0.3, 1 };
            data[24] = new double[] { 24, 0.38, 0.14, 1 };
            data[25] = new double[] { 25, 0.58, 0.13, 2 };
            data[26] = new double[] { 26, 0.57, 0.19, 2 };
            data[27] = new double[] { 27, 0.66, 0.14, 2 };
            data[28] = new double[] { 28, 0.64, 0.24, 2 };
            data[29] = new double[] { 29, 0.71, 0.22, 2 };

            return data;
        }

        public static double DistanceFunc(double[] item, double[] data)
        {
            double sum = 0d;
            for (int i = 1; i <= 2; i++)
            {
                sum += Math.Pow((data[i] - item[i - 1]), 2);
            }

            return Math.Sqrt(sum);
        }

        public static void PrintArrTest(double[] arr)
        {
            foreach (double a in arr)
            {
                Console.WriteLine(a + " ");
            }
            Console.WriteLine("\n");
        }

        public static void PrintArrTest(int[] arr)
        {
            foreach (int a in arr)
            {
                Console.WriteLine(a + " ");
            }
            Console.WriteLine("\n");
        }
    }

}
