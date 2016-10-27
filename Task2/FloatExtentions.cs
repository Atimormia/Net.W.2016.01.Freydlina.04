using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class FloatExtentions
    {
        public static byte[] ToBitArray(this Single number)
        {
            uint fb = Convert.ToUInt32(number);
            byte[] bSign = new byte[1];

            int sign = (int)((fb >> 31) & 1);
            int exponent = (int)((fb >> 23) & 0xFF);
            int mantissa = (int)(fb & 0x7FFFFF);

            bSign[0] = (byte)sign;
        
            //float fMantissa;

            //if (exponent != 0)
            //{
            //    exponent -= 127;
            //    fMantissa = 1.0f + (mantissa / (float)0x800000);
            //}
            //else
            //{
            //    if (mantissa != 0)
            //    {
            //        // denormal
            //        exponent -= 126;
            //        fMantissa = 1.0f / (float)0x800000;
            //    }
            //    else
            //    {
            //        // +0 and -0 cases
            //        fMantissa = 0;
            //    }
            //}

            byte[] bExponent = CalculateBits(exponent);
            byte[] bMantissa = CalculateBits(mantissa);//(int)fMantissa);

            return ConcatByteArrs(bSign, bExponent, bMantissa);

        }

        private static int BitsCount(int value)
        {
            int i = 0;
            while (value != 0)
            {
                value /= 2;
                i++;
            }
            return i;
        }

        private static byte[] CalculateBits(int number)
        {
            int bufNumber = number;
            int bitsCount = BitsCount(number);
            byte[] bits = new byte[bitsCount];
            
            for (int i = 0; i < bitsCount; i++)
            {
                bits[i] = (byte)(bufNumber % 2);
                bufNumber /= 2;
            }

            return bits;
        }

        private static byte[] ConcatByteArrs(byte[] arr1, byte[] arr2, byte[] arr3)
        {
            byte[] res = new byte[arr1.Length+arr2.Length+arr3.Length];

            for (int i = 0; i < arr1.Length; i++)
            {
                res[i] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                res[arr1.Length + i] = arr2[i];
            }

            for (int i = 0; i < arr3.Length; i++)
            {
                res[arr1.Length + arr2.Length + i] = arr3[i];
            }

            return res;
        }
    }
}
