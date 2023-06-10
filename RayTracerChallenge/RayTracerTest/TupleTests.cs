using RayTracerLib;
using Math = RayTracerLib.Math;
using Tuple = RayTracerLib.Tuple;

namespace RayTracerTest
{
    [TestClass]
    public class TupleTests
    {
        [TestMethod]
        public void CreateTupleAsPointShouldInitializeWithCorrectValues()
        {
            var tuple = new Tuple(4.3f, -4.2f, 3.1f, 1.0f);
            Assert.IsTrue(Math.Equals(tuple.X, 4.3f));
            Assert.IsTrue(Math.Equals(tuple.Y, -4.2f));
            Assert.IsTrue(Math.Equals(tuple.Z, 3.1f));
            Assert.IsTrue(Math.Equals(tuple.W, 1.0f));
            Assert.IsTrue(tuple.IsPoint());
            Assert.IsFalse(tuple.IsVector());
        }

        [TestMethod]
        public void CreateTupleAsVectorShouldInitializeWithCorrectValues()
        {
            var tuple = new Tuple(4.3f, -4.2f, 3.1f, 0.0f);
            Assert.IsTrue(Math.Equals(tuple.X, 4.3f));
            Assert.IsTrue(Math.Equals(tuple.Y, -4.2f));
            Assert.IsTrue(Math.Equals(tuple.Z, 3.1f));
            Assert.IsTrue(Math.Equals(tuple.W, 0.0f));
            Assert.IsTrue(tuple.IsVector());
            Assert.IsFalse(tuple.IsPoint());
        }

        [TestMethod]
        public void CreatePointTupleShouldBePoint()
        {
            var tuple = Tuple.Point(4, -4, 3);
            Assert.IsTrue(tuple.IsPoint());
        }

        [TestMethod]
        public void CreateVectorTupleShouldBeVector()
        {
            var tuple = Tuple.Vector(4, -4, 3);
            Assert.IsTrue(tuple.IsVector());
        }

        [TestMethod]
        public void CompareSimilarTuplesShouldBeEqual()
        {
            var tupleOne = Tuple.Vector(4, -4, 3);
            var tupleTwo = Tuple.Vector(4, -4, 3);
            Assert.IsTrue(tupleOne == tupleTwo);
        }

        [TestMethod]
        public void CompareDifferentTuplesShouldNotBeEqual()
        {
            var tupleOne = Tuple.Vector(4, -4, 3);
            var tupleTwo = Tuple.Point(4, -4, 3);
            Assert.IsTrue(tupleOne != tupleTwo);
        }

        [TestMethod]
        public void AddVectorAndPointShouldEqualPoint()
        {
            var vector = Tuple.Vector(1, 2, 3);
            var point = Tuple.Point(1, 1, 1);
            var expectedResult = Tuple.Point(2, 3, 4);

            Assert.AreEqual(expectedResult, point + vector);
        }

        [TestMethod]
        public void AddVectorAndVectorShouldEqualVector()
        {
            var vectorOne = Tuple.Vector(1, 2, 3);
            var vectorTwo = Tuple.Vector(1, 2, 3);
            var expectedResult = Tuple.Vector(2, 4, 6);

            Assert.AreEqual(expectedResult, vectorTwo + vectorOne);
        }

        [TestMethod]
        public void SubtractTwoPointsShouldEqualVector()
        {
            var pointOne = Tuple.Point(2, -2, 2);
            var pointTwo = Tuple.Point(-1, 1, -1);
            var expectedResult = Tuple.Vector(3, -3, 3);

            Assert.AreEqual(expectedResult, pointOne - pointTwo);
        }

        [TestMethod]
        public void SubtractVectorFromPointEqualsPoint()
        {
            var point = Tuple.Point(2, 3, 4);
            var vector = Tuple.Vector(1, 1, -1);
            var result = Tuple.Point(1, 2, 5);
            Assert.AreEqual(result, point - vector);
        }

        [TestMethod]
        public void SubtractVectorFromVectorEqualsVector()
        {
            var vectorOne = Tuple.Vector(1, 2, 3);
            var vectorTwo = Tuple.Vector(-1, 2, -3);
            var result = Tuple.Vector(2, 0, 6);
            Assert.AreEqual(result, vectorOne - vectorTwo);
        }

        [TestMethod]
        public void NegationVectorEqualsVector()
        {
            var vector = Tuple.Vector(1, 2, 3);
            var result = Tuple.Vector(-1, -2, -3);
            Assert.AreEqual(result, -vector);
        }

        [TestMethod]
        public void MultiplyVectorScalesUp()
        {
            var vector = Tuple.Vector(1, 2, 3);
            var result = Tuple.Vector(1.5f, 3, 4.5f);
            Assert.AreEqual(result, vector * 1.5f);
        }

        [TestMethod]
        public void MultiplyVectorScalesDown()
        {
            var vector = Tuple.Vector(2, 4, 6);
            var result = Tuple.Vector(1, 2, 3);
            Assert.AreEqual(result, vector * 0.5f);
        }

        [TestMethod]
        public void DivideVectorScalesUp()
        {
            var vector = Tuple.Vector(1, 2, 3);
            var result = Tuple.Vector(2f, 4, 6f);
            Assert.AreEqual(result, vector / 0.5f);
        }

        [TestMethod]
        public void DivideVectorScalesDown()
        {
            var vector = Tuple.Vector(2, 4, 6);
            var result = Tuple.Vector(1, 2, 3);
            Assert.AreEqual(result, vector / 2f);
        }

        [TestMethod]
        public void SimpleVectorMagnitude()
        {
            var v1 = Tuple.Vector(0, 0, 1);
            var result = 1.0f;
            Assert.IsTrue(Math.Equals(v1.Magnitude(), result));
        }

        [TestMethod]
        public void ComplexVector()
        {
            var v1 = Tuple.Vector(1, 2, 3);
            var v1Mag = v1.Magnitude();
            var result = (float)System.Math.Sqrt(14);
            Assert.IsTrue(Math.Equals(v1Mag, result));
        }

        [TestMethod]
        public void SimpleNormalizationTest()
        {
            var v1 = Tuple.Vector(4, 0, 0);
            var normalized = v1.Normalize();
            var result = Tuple.Vector(1, 0, 0);
            Assert.AreEqual(normalized, result);
        }

        [TestMethod]
        public void ComplexNormalizationTest()
        {
            var v1 = Tuple.Vector(1, 2, 3);
            var normalized = v1.Normalize();
            var result = Tuple.Vector(0.26726f, 0.53452f, 0.80178f);
            Assert.AreEqual(normalized, result);

        }

        [TestMethod]
        public void MagnitudeOfNormalizedVectorTest()
        {
            var v1 = Tuple.Vector(1, 2, 3);
            var normalized = v1.Normalize();
            Assert.IsTrue(Math.Equals(1, normalized.Magnitude()));
        }

        [TestMethod]
        public void DotProductTest()
        {
            var v1 = Tuple.Vector(1, 2, 3);
            var v2 = Tuple.Vector(2, 4, 6);
            var result = v1.DotProduct(v2);
            Assert.IsTrue(Math.Equals(result, 28));
        }

        [TestMethod]
        public void CrossProductTest()
        {
            var v1 = Tuple.Vector(1, 2, 3);
            var v2 = Tuple.Vector(2, 3, 4);

            var result1 = Tuple.Vector(-1, 2, -1);
            var result2 = Tuple.Vector(1, -2, 1);

            Assert.IsTrue(Math.Equals(result1, v1.CrossProduct(v2)));
            Assert.IsTrue(Math.Equals(result2, v2.CrossProduct(v1)));
        }
    }
}