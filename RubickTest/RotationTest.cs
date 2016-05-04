using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rubick;

namespace RubickTest
{
    [TestClass]
    public class RotationTest
    {
        // Tests for Matrix-Constructor

        [TestMethod]
        public void MatrixConstructor_onValidMatrix_ObjectConstructedRetrievesMatrix()
        {
            sbyte[,] original = new sbyte[3, 3]
            {
                { 1, 0, 0 },
                { 0, 0, -1 },
                { 0, 1, 0 }
            };
            Rotation rotation = new Rotation(original);
            sbyte[,] retrieved = rotation.Matrix;
            CollectionAssert.AreEqual(original, retrieved);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MatrixConstructor_onInvalidMatrix_throwsArgumentOutOfRangeException()
        {
            sbyte[,] input = new sbyte[3, 3]
            {
                { 1, 0, 0 },
                { 1, 0, 0 },
                { 1, 0, 0 }
            };
            Rotation rotation = new Rotation(input);
        }

        [TestMethod]
        public void MatrixConstructor_onNull_constructsUndefinedRotation()
        {
            Rotation rotation = new Rotation(null);
            Assert.AreEqual(false, rotation.Defined);
        }

        // Tests for Binary Constructor

        [TestMethod]
        public void BinaryConstructor_parsesMinusOne_asUndefinedRotation()  // -1 is the only-ones sample
        {
            int sample = -1;
            Rotation rotation = new Rotation(sample);
            Assert.AreEqual(false, rotation.Defined);
        }

        // Bits beyond 18th should result in FormatException (provided that sample is not -1):
        [TestMethod, ExpectedException(typeof(FormatException))]
        public void BinaryConstructor_onOneLeftshiftThirtyOne_throwsFormatException()
        {
            int sample = 1 << 31;  // value: - 2 ^ 31
            Rotation rotation = new Rotation(sample);
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void BinaryConstructor_onOneLeftshiftEighteen_throwsFormatException()
        {
            int sample = 1 << 18;  // value: 2 ^ 18
            Rotation rotation = new Rotation(sample);
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void BinaryConstructor_onOneLeftshiftTwenty_throwsFormatException()
        {
            int sample = 1 << 20;  // value: 2 ^ 20
            Rotation rotation = new Rotation(sample);
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void BinaryConstructor_onOneLeftshiftTwentySix_throwsFormatException()
        {
            int sample = 1 << 26;  // value: 2 ^ 18
            Rotation rotation = new Rotation(sample);
        }

        // If there are no bits after 18th, constructor should parse first 18 as the elements of a matrix
        // -- possibly resulting in ArgumentOutOfRangeException:
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryConstructor_onOneLeftshiftSeventeen_throwsArgumentOutOfRangeException()
        {
            int sample = 1 << 17;
            Rotation rotation = new Rotation(sample);
        }

        // Combining the above should result FormatException:
        [TestMethod, ExpectedException(typeof(FormatException))]
        public void BinaryConstructor_onRandomSampleHavingBitsOverEighteenth_throwsFormatException()
        {
            int sample = 123 << 18 | 456;
            Rotation rotation = new Rotation(sample);
        }

        // Playing with invalid matrix-values:
        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryConstructor_onOnlyZerosSample_throwsArgumentOutOfRangeException()  // nullmatrix is the most trivial invalid matrix
        {
            int sample = 0;
            Rotation rotation = new Rotation(sample);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BinaryConstructor_onSampleOfRandomInvalidMatrix_throwsArgumentOutOfRangeException()  // it's an ugly example
        {
            /*sbyte[,] matrix = new sbyte[3, 3]
            {
                { -1, 0, 1 },
                { 0, 1, 6 },
                { 0, 0, -1 }
            };*/
            int sample =
                (-1 & 3) << 16 | (0 & 3) << 14 | (1 & 3) << 12 |
                (0 & 3) << 10 | (1 & 3) << 8 | (6 & 3) << 6 |
                (0 & 3) << 4 | (0 & 3) << 2 | (-1 & 3) << 0;
            Rotation rotation = new Rotation(sample);
        }

        [TestMethod]
        public void BinaryConstructor_onSampleOfValidRotation_ObjectRestoredRetrievesMatrix()
        {
            sbyte[,] matrix = new sbyte[3, 3]
            {
                { -1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, -1 }
            };
            Rotation original = new Rotation(matrix);
            int bitSample = original.GetBinary();
            Rotation restored = new Rotation(bitSample);
            CollectionAssert.AreEqual(matrix, restored.Matrix);
        }

        [TestMethod]
        public void BinaryConstructor_onSampleOfUndefinedRotation_restoresUndefinedRotation()
        {
            Rotation original = new Rotation(null);
            int bitSample = original.GetBinary();
            Rotation restored = new Rotation(bitSample);
            Assert.AreEqual(false, restored.Defined);
        }
    }
}
