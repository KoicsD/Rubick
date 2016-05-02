using System;

namespace Rubick
{
    public class Rotation
    {
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
            if (!Validator.IsValidRotation(matrix, out message))
                throw new ArgumentOutOfRangeException("matrix", message);
            this.matrix = matrix;
            defined = true;
        }
    }
}
