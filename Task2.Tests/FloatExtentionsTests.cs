using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class FloatExtentionsTests
    {
        [TestCase(10,ExpectedResult = new byte[]{0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0})]
        public byte[] ToBitArrayTest(float number)
        {
            return number.ToBitArray();
        }
    }
}
