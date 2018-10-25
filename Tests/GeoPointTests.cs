using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistanceBetweenTwoGeoPoints;

namespace Tests
{
    [TestClass]
    public class GeoPointTests
    {
        GeoPoint start = new GeoPoint(4d, 5d);
        GeoPoint end = new GeoPoint(2d, 6d);

        [TestMethod]
        public void CalculationDistanceToPointStatic()
        {
            var actual = GeoPoint.CalculationDistanceToPoint(1d, 2d, 3d, 4d);

            Assert.AreEqual(expected: 5d, actual: actual);
        }

        [TestMethod]
        public void CalculationDistanceToPoint()
        {
            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: 5d, actual: actual);
        }
    }
}
