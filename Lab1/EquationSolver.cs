using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1
{
    public class EquationSolver
    {
        public static string[] Get(int a, int b, int c)
        {
            var discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
                return (new[] {
                    (-b + Math.Sqrt(discriminant)) / (2 * a),
                    (-b - Math.Sqrt(discriminant)) / (2 * a)
                }).Select(x => x.ToString()).ToArray();

            if (discriminant == 0)
                return (new[] { -b / (2 * a) }).Select(x => x.ToString()).ToArray();

            return new[] { "Корни отсутствуют" };
        }
    }
}

