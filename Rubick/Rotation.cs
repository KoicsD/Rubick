using System;

namespace Rubick
{
    /// <summary cref="Rotation">
    /// This class is intended to store the rotation of a cell in the cube.
    /// <para>There are 24 values for a Rotation object and an extra undefined value is also supported.</para>
    /// <para>Instances can be created either by specifing the matrix of the rotation, or from binary form.</para>
    /// <para>Both the matrix and the binary form can be retrieved.</para>
    /// </summary>
    public class Rotation
    {
        // the spirit:
        private sbyte[,] matrix;

        // Properties:

        /// <summary cref="Defined"> Signs if the current object is a defined Rotation with a valid Matrix. </summary>
        public bool Defined { get { return matrix != null ? true : false; } }

        /// <summary cref="Matrix"> Retrieves rotation-matrix. </summary>
        public sbyte[,] Matrix { get { return matrix; } }

        // Constructors:

        /// <summary cref="Rotation(sbyte[,])">
        /// Constructs Rotation object from matrix.
        /// <para>
        /// <list type="bullet">
        /// <item><paramref name="matrix"/> must have size of 3x3.</item>
        /// <item>None of the elements in <paramref name="matrix"/> can be other than 1, 0 or -1.</item>
        /// <item><paramref name="matrix"/> must have exactly 3 non-zero elements.</item>
        /// <item>Each non-zero element must be in a separate row and column.</item>
        /// <item><paramref name="matrix"/> must have determinant value of 1.</item>
        /// </list>
        /// </para>
        /// </summary>
        /// <param name="matrix">
        /// A 3x3 Array of sbyte-s as the matrix form of the Rotation.
        /// <para>
        /// <list type="bullet">
        /// <item>Matrix must have size of 3x3.</item>
        /// <item>None of the elements in matrix can be other than 1, 0 or -1.</item>
        /// <item>Matrix must have exactly 3 non-zero elements.</item>
        /// <item>Each non-zero element must be in a separate row and column.</item>
        /// <item>Matrix must have determinant value of 1.</item>
        /// </list>
        /// </para>
        /// </param>
        public Rotation(sbyte[,] matrix)
        {
            this.matrix = matrix;
            EnsureValidity();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binary">A 32-bit integer representing the bit-sample of the rotation-matrix, or -1 if undefined.</param>
        public Rotation(int binary)
        {
            if (binary == -1)  // only-ones means
            {
                this.matrix = null;  // undefined
                return;
            }
            if (binary >= 1 << 18 || binary < 0)
                throw new FormatException("The first 14 bits of the 32-bit binary must be zeros");
            this.matrix = new sbyte[3, 3];
            for (sbyte i = 2; i >= 0; --i)  // reverse iteration over rows
            {
                for (sbyte j = 2; j >= 0; --j)  // reverse iteration over sbytes in row
                {
                    this.matrix[i, j] = (sbyte)((binary & 1) - (binary & 2));  // 2-bit integer to sbyte
                    binary >>= 2;  // go to next 2 bits
                }
            }
            EnsureValidity();
        }

        public int GetBinary()
        {
            if (!Defined)
                return -1;
            int binary = 0;
            for (byte i = 0; i < 3; ++i)
            {
                for (byte j = 0; j < 3; ++j)
                {
                    binary <<= 2;  // free 2 bits on the end
                    binary |= this.matrix[i, j] & 3;  // sbyte to 2-bit int, 3 is a mask: 11b
                }
            }
            return binary;
        }

        private void EnsureValidity()
        {
            if (Defined)
                switch (Validator.ValidateRotation(matrix))
                {
                    case Validator.RotationValidity.InvalidSize:
                        throw new ArgumentOutOfRangeException("matrix", "Matrix must have size of 3x3");
                    case Validator.RotationValidity.ElementOutOfRange:
                        throw new ArgumentOutOfRangeException("matrix", "None of the elements in matrix can be other than 0, 1 or -1");
                    case Validator.RotationValidity.NotSixZeros:
                        throw new ArgumentOutOfRangeException("matrix", "Matrix must have exactly 3 non-zero elements");
                    case Validator.RotationValidity.Singular:
                        throw new ArgumentOutOfRangeException("matrix", "Each non-zero element must be in a separate row and column");
                    case Validator.RotationValidity.Mirrored:
                        throw new ArgumentOutOfRangeException("matrix", "Matrix must have determinant value of 1");
                    case Validator.RotationValidity.Valid:
                        return;
                }
        }
    }
}
