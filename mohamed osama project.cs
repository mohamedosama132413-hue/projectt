using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] data = {
            115, 182, 191, 31, 196, 1099, 5, 172, 10, 179, 83,
            21, 20, 21, 186, 177, 195, 193, 188, 199, 62, 109,
            105, 183, 110
        };

        int n = data.Length;


        Array.Sort(data);


        double mean = data.Average();


        double median = (n % 2 == 0) ?
            (data[n / 2 - 1] + data[n / 2]) / 2.0 :
            data[n / 2];

        var mode = data.GroupBy(x => x)
                       .OrderByDescending(g => g.Count())
                       .First().Key;

        double variance = data.Select(x => Math.Pow(x - mean, 2)).Average();

        double stdDev = Math.Sqrt(variance);

        double P20 = Percentile(data, 20);
        double P50 = Percentile(data, 50);

        double Q1 = Percentile(data, 25);
        double Q2 = median;
        double Q3 = Percentile(data, 75);

        int range = data.Max() - data.Min();

        double IQR = Q3 - Q1;

        int sum = data.Sum();

        Console.WriteLine("Mean = " + mean);
        Console.WriteLine("Mode = " + mode);
        Console.WriteLine("Median = " + median);
        Console.WriteLine("Variance = " + variance);
        Console.WriteLine("P20 = " + P20);
        Console.WriteLine("P50 = " + P50);
        Console.WriteLine("Q1 = " + Q1);
        Console.WriteLine("Q2 = " + Q2);
        Console.WriteLine("Q3 = " + Q3);
        Console.WriteLine("Range = " + range);
        Console.WriteLine("IQR = " + IQR);
        Console.WriteLine("Standard Deviation = " + stdDev);
        Console.WriteLine("Sum = " + sum);
    }

    static double Percentile(int[] sortedData, double percentile)
    {
        int n = sortedData.Length;
        double index = (percentile / 100.0) * (n - 1);
        int lower = (int)Math.Floor(index);
        int upper = (int)Math.Ceiling(index);

        if (lower == upper)
            return sortedData[lower];

        return sortedData[lower] + (index - lower) * (sortedData[upper] - sortedData[lower]);
    }
}

