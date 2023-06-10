using RayTracerLib;
using System.Drawing;
using Color = RayTracerLib.Color;
using Math = RayTracerLib.Math;
using Tuple = RayTracerLib.Tuple;

namespace RayTracerTest
{
    [TestClass]
    public class ColorTests
    {
        [TestMethod]
        public void InitializeColorTest()
        {
            var color = new Color(-0.5f, 0.4f, 1.7f);
            Assert.IsTrue(Math.Equals(color.Red, -0.5f));
            Assert.IsTrue(Math.Equals(color.Green, 0.4f));
            Assert.IsTrue(Math.Equals(color.Blue, 1.7f));
        }

        [TestMethod]
        public void AddColorsTest()
        {
            var c1 = new Color(0.9f, 0.6f, 0.75f);
            var c2 = new Color(0.7f, 0.1f, 0.25f);
            var result = c1 + c2;
            var expected = new Color(1.6f, 0.7f, 1.0f);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void SubtractColorsTest()
        {
            var c1 = new Color(0.9f, 0.6f, 0.75f);
            var c2 = new Color(0.7f, 0.1f, 0.25f);
            var result = c1 - c2;
            var expected = new Color(0.2f, 0.5f, 0.5f);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void ScalarMultiplyColorsTest()
        {
            var c1 = new Color(0.2f, 0.3f, 0.4f);
            var result = c1 * 2;
            var expected = new Color(0.4f, 0.6f, 0.8f);
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void MultipleMultipleColorsTest()
        {
            var c1 = new Color(1f, 0.2f, 0.4f);
            var c2 = new Color(0.9f, 1f, 0.1f);
            var result = c1 * c2;
            var expected = new Color(0.9f, 0.2f, 0.04f);
            Assert.AreEqual(result, expected);
        }
    }
}