using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1
{
    public class GetFibonacciNumber
    {
        public static long Get(long index)
        {
            if (index == 0 || index == 1)
                return index;

            return Get(index - 1) + Get(index - 2);
        }
    }
}
