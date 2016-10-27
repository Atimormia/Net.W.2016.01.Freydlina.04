using System;
using System.Collections.Generic;
using NUnit.Framework;
using Task1;

namespace NewtonTests
{
    [TestFixture]
    public class NewtonTests
    {
        #region Test method: public static double NewtonSqrt(double value)
        public static IEnumerable<TestCaseData> TestCasesForNewtonNthSqrt
        {
            get
            {
                yield return new TestCaseData(4, 2).Returns(Math.Sqrt(4));
                yield return new TestCaseData(3, 2).Returns(Math.Sqrt(3));
                yield return new TestCaseData(1,1).Returns(1);
                yield return new TestCaseData(int.MaxValue,2).Returns(Math.Sqrt(int.MaxValue));
                yield return new TestCaseData(Math.Pow(1234567,4),4).Returns(1234567);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForNewtonNthSqrt))]
        public double TestNewtonSqrt(double value, int degree)
        {
            return Newton.NewtonNthSqrt(value,degree);

        }

        public static IEnumerable<TestCaseData> TestCasesForNewtonNthSqrtThrows
        {
            get
            {
                yield return new TestCaseData(-1, 2);
                yield return new TestCaseData(0, 2);
                yield return new TestCaseData(5, 0);
            }
        }

        [Test, TestCaseSource(nameof(TestCasesForNewtonNthSqrtThrows))]
        public void TestNewtonSqrtThrows(double value, int degree)
        {
            Assert.That(() => Newton.NewtonNthSqrt(value, degree), Throws.TypeOf<ArgumentException>());

        }
        #endregion

    }
}
