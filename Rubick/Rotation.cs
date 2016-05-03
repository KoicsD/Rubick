using System;

namespace Rubick
{
    public class Rotation
    {
        private sbyte[,] matrix;

        public bool Defined { get { return matrix != null ? true : false; } }
        public sbyte[,] Matrix { get { return matrix; } }

        public Rotation(sbyte[,] matrix)
        {
            this.matrix = matrix;
            EnsureValidity();
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
                        throw new ArgumentOutOfRangeException("matrix", "Each non-zero elements must be in a separate row and column");
                    case Validator.RotationValidity.Mirrored:
                        throw new ArgumentOutOfRangeException("matrix", "Matrix must have determinant value of 1");
                    case Validator.RotationValidity.Valid:
                        return;
                }
        }
    }
}
