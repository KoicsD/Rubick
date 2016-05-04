using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rubick;

namespace RubickTest
{
    [TestClass]
    public class ValidatorTest
    {
        // Testing determinant-calculator

        // Some trivial examples:
        [TestMethod]
        public void Get3by3Determinant_onZeros_returnsZero()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, 0 },
                { 0, 0, 0 },
                { 0, 0, 0 }
            };
            int estimation = 0;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onOnes_returnsZero()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 1, 1 },
                { 1, 1, 1 },
                { 1, 1, 1 }
            };
            int estimation = 0;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onEye_returnsOne()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 0, 1 }
            };
            int estimation = 1;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        //Determinant is definitely zero if one column or row is zero:
        [TestMethod]
        public void Get3by3Determinant_onOneColZero_returnsZero()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 2 },
                { 3, 0, 4 },
                { 5, 0, 6 }
            };
            int estimation = 0;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onOneRowZero_returnsZero()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 2, 3 },
                { 0, 0, 0 },
                { 4, 5, 6 }
            };
            int estimation = 0;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        // Or if two columns or two rows are equal:
        [TestMethod]
        public void Get3by3Determinant_onTwoColsEqual_returnsZero()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 1, 2 },
                { 3, 3, 4 },
                { 5, 5, 6 }
            };
            int estimation = 0;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onTwoRowsEqual_returnsZero()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 2, 3 },
                { 1, 2, 3 },
                { 4, 5, 6 }
            };
            int estimation = 0;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        // Only ones, only in cross-diagonal results minus one,
        // since it is based on an odd permutation:
        [TestMethod]
        public void Get3by3Determinant_onCrossdiagOnes_returnsMinusOne()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, 1 },
                { 0, 1, 0 },
                { 1, 0, 0 }
            };
            int estimation = -1;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        // Multiplying nxn matrix by a scalar,
        // determinant is proportional to the scalar to power n
        // (in our example, n == 3):
        [TestMethod]
        public void Get3by3Determinant_onTwiceEye_returnsTwoCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 2, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 2 }
            };
            int estimation = 2 * 2 * 2;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onThreeTimesEye_returnsThreeCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 3, 0, 0 },
                { 0, 3, 0 },
                { 0, 0, 3 }
            };
            int estimation = 3 * 3 * 3;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onFourTimesEye_returnsFourCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 4, 0, 0 },
                { 0, 4, 0 },
                { 0, 0, 4 }
            };
            int estimation = 4 * 4 * 4;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onFiveTimesEye_returnsFiveCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 5, 0, 0 },
                { 0, 5, 0 },
                { 0, 0, 5 }
            };
            int estimation = 5 * 5 * 5;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onCrossdiagTwoes_returnsMinusTwoCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, 2 },
                { 0, 2, 0 },
                { 2, 0, 0 }
            };
            int estimation = -(2 * 2 * 2);
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onCrossdiagThrees_returnsMinusThreeCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, 3 },
                { 0, 3, 0 },
                { 3, 0, 0 }
            };
            int estimation = -(3 * 3 * 3);
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onCrossdiagFours_returnsMinusFourCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, 4 },
                { 0, 4, 0 },
                { 4, 0, 0 }
            };
            int estimation = -(4 * 4 * 4);
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onCrossdiagFives_returnsMinusFiveCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, 5 },
                { 0, 5, 0 },
                { 5, 0, 0 }
            };
            int estimation = -(5 * 5 * 5);
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onMinusFiveTimesEye_returnsMinusFiveCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { -5, 0, 0 },
                { 0, -5, 0 },
                { 0, 0, -5 }
            };
            int estimation = -(5 * 5 * 5);
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void Get3by3Determinant_onCrossdiagMinusFives_returnsFiveCubed()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 0, 0, -5 },
                { 0, -5, 0 },
                { -5, 0, 0 }
            };
            int estimation = 5 * 5 * 5;
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        // A bit more general example:
        [TestMethod]
        public void Get3by3Determinant_EasySample()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 0 }
            };
            int estimation = 1 * (5 * 0 - 6 * 8) + 2 * (6 * 7 - 4 * 0) + 3 * (4 * 8 - 5 * 7);
            int output = Validator.Get3by3Determinant(input);
            Assert.AreEqual(estimation, output);
        }

        // Testing exceptions:
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Get3by3Determinant_onWrongSize_throwsArgumentException()
        {
            sbyte[,] input = new sbyte[2, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            };
            Validator.Get3by3Determinant(input);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Get3by3Determinant_onNull_throwsArgumentNullException()
        {
            sbyte[,] input = null;
            Validator.Get3by3Determinant(input);
        }

        // Testing Rotation-Validator generally

        // 8 enum-values:
        [TestMethod]
        public void ValidateRotation_recognizesElementOutOfRange()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.ElementOutOfRange;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesWrongSize()
        {
            sbyte[,] input = new sbyte[2, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.InvalidSize;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesTooManyNonzeroElements()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, -1 },
                { 0, 0, 1 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.NotSixZeros;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesTooFewNonzeroElements()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, -1, 0 },
                { 0, 0, 0 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.NotSixZeros;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesMoreThanOneNonzeroInOneCol()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.Singular;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesMoreThanOneNonzeroInOneRow()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.Singular;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesDeterminantMinusOne()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 0, 1 },
                { 0, 1, 0 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.Mirrored;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void ValidateRotation_recognizesValidPerpendicularRotation()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 0, -1 },
                { 0, 1, 0 }
            };
            Validator.RotationValidity estimation = Validator.RotationValidity.Valid;
            Validator.RotationValidity output = Validator.ValidateRotation(input);
            Assert.AreEqual(estimation, output);
        }

        // On null, exception:
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void ValidateRotation_onNull_throwsArgumentNullException()
        {
            sbyte[,] input = null;
            Validator.ValidateRotation(input);
        }
    }
}
