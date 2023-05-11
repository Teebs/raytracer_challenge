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

    }
}