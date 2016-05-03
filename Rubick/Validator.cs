using System;

namespace Rubick
{
    public static class Validator
    {
        public enum RotationValidity { Valid, Mirrored, Singular, NotSixZeros, ElementOutOfRange, InvalidSize }

        public static RotationValidity ValidateRotation(sbyte[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix", "Argument cannot be null.");
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
                return RotationValidity.InvalidSize;
            byte numberOfNonzeros = 0;
            foreach (sbyte element in matrix)
            {
                if (element > 1 || element < -1)
                    return RotationValidity.ElementOutOfRange;
                if (element != 0)
                    ++numberOfNonzeros;
            }
            if (numberOfNonzeros != 3)
                return RotationValidity.NotSixZeros;
            if (Get3by3Determinant(matrix) == 0)
                return RotationValidity.Singular;
            if (Get3by3Determinant(matrix) != 1)
                return RotationValidity.Mirrored;
            return RotationValidity.Valid;
        }

        public static int Get3by3Determinant(sbyte[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix", "Argument cannot be null.");
            if (matrix.GetLength(0) != 3 || matrix.GetLength(1) != 3)
                throw new ArgumentException("Array must have size of 3x3", "matrix");
            int determinant = 0;
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
    }
}
