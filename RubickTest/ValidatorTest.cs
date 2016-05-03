using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Rubick;

namespace RubickTest
{
    [TestClass]
    public class ValidatorTest
    {
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

        [TestMethod]
        public void IsValidRotation_onElementOutOfRange_returnsFalse()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 2, 0 },
                { 0, 0, 3 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onWrongSize_returnsFalse()
        {
            sbyte[,] input = new sbyte[2, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onTooManyNonzeroElements_returnsFalse()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, -1 },
                { 0, 0, 1 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onTooFewNonzeroElements_returnsFalse()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, -1, 0 },
                { 0, 0, 0 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onMoreThanOneNonzeroInOneCol_returnsFalse()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 0 },
                { 0, 1, 0 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onMoreThanOneNonzeroInOneRow_returnsFalse()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onDeterminantMinusOne_returnsFalse()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 0, 1 },
                { 0, 1, 0 }
            };
            bool estimation = false;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod]
        public void IsValidRotation_onValidPerpendicularRotation_returnsTrue()
        {
            sbyte[,] input = new sbyte[3, 3] {
                { 1, 0, 0 },
                { 0, 0, -1 },
                { 0, 1, 0 }
            };
            bool estimation = true;
            string message;
            bool output = Validator.IsValidRotation(input, out message);
            Assert.AreEqual(estimation, output);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void IsValidRotation_onNull_throwsArgumentNullException()
        {
            sbyte[,] input = null;
            string message;
            Validator.IsValidRotation(input, out message);
        }
    }
}
