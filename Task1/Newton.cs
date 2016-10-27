using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Newton
    {
        private const double e = 0.0000000000000001;

        public static double NewtonNthSqrt(double value, int degree)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Value must be positive");
            }
            if (degree == 0)
            {
                throw new ArgumentException("Degree must not be 0");
            }
            int degreeAbs = Math.Abs(degree);
            bool degreeIsNegative = degree != degreeAbs;
            degree = degreeAbs;

            double result = value;
            double accuracy = 1;
            while (accuracy >= e)
            {
                double currentValue = ((degree - 1) * result + value / Math.Pow(result, degree - 1)) / degree;
                accuracy = Math.Abs(result - currentValue);
                result = currentValue;
            }

            if (degreeIsNegative)
            {
                return Math.Round(1d/result, 10);
            }
            return result;
        }
    }
}
