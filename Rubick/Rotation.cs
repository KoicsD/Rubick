using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubick
{
    public class Rotation
    {
        public static bool IsValid(sbyte[,] matrix, out string message)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix", "Argument cannot be null.");
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
            {
                message = "Matrix must have size of 3x3";
                return false;
            }
            byte numberOfNonzeros = 0;
            foreach (sbyte element in matrix)
            {
                if (element > 1 || element < -1)
                {
                    message = "None of the elements in matrix can be other than 0, 1 or -1";
                    return false;
                }
                if (element != 0)
                    ++numberOfNonzeros;
            }
            if (numberOfNonzeros != 3)
            {
                message = "Matrix must have exactly 3 non-zero elements.";
                return false;
            }
            if (Get3by3Determinant(matrix) != 1)
            {
                message = "Matrix must have determinant value of 1.";
                return false;
            }
            message = "Matrix is correct.";
            return true;
        }

        public static long Get3by3Determinant(sbyte[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix", "Argument cannot be null.");
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
                throw new ArgumentException("Array must have size of 3x3", "matrix");
            long determinant = 0;
            for (byte i = 0; i < 3; ++i)
            {
                for (byte j = 0; j < 3; ++j)
                {
                    for (byte k = 0; k < 3; ++k)
                    {
                        if (i == j || j == k || k == i)
                            continue;
                        if (GetNumberOfInversions(i, j, k) % 2 == 0)
                            determinant += matrix[0, i] * matrix[1, j] * matrix[2, k];
                        else
                            determinant -= matrix[0, i] * matrix[1, j] * matrix[2, k];
                    }
                }
            }
            return determinant;
        }

        public static byte GetNumberOfInversions(byte i, byte j, byte k)
        {
            byte numberOfInversions = 0;
            if (i > j)
                ++numberOfInversions;
            if (i > k)
                ++numberOfInversions;
            if (j > k)
                ++numberOfInversions;
            return numberOfInversions;
        }

        sbyte[,] matrix;
        bool defined;

        public bool Defined { get { return defined; } }
        public sbyte[,] Matrix { get { return matrix; } }

        public Rotation(sbyte[,] matrix)
        {
            if (matrix == null)
            {
                defined = false;
                this.matrix = null;
                return;
            }
            string message;
            if (!IsValid(matrix, out message))
                throw new ArgumentOutOfRangeException("matrix", message);
            this.matrix = matrix;
            defined = true;
        }
    }
}
