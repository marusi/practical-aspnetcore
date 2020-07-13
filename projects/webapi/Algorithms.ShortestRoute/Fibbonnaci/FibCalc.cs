using System.Collections.Generic;


namespace Algorithms.ShortestRoute.Fibbonnaci
{

    public class FibonacciCalc
    {
       
        public ulong Recursive(ulong n)
        {
            if (n == 1 || n == 2) return 1;
            return Recursive(n - 2) + Recursive(n - 1);
        }

       
        public ulong RecursiveWithMemoization(ulong n)
        {
            return 0;
        }

       
        public ulong Iterative(ulong n)
        {
            return 0;
        }

        public IEnumerable<ulong> Data()
        {
            yield return 15;
            yield return 35;
        }
    }
}