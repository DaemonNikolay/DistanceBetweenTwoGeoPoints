using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistanceBetweenTwoGeoPoints;

namespace Tests
{
    [TestClass]
    public class GeoPointTests
    {
        GeoPoint start = new GeoPoint(55.720224, 37.629893); //Moskau
        GeoPoint end = new GeoPoint(33.857982, 9.526866); //Tunis

        [TestMethod]
        public void CalculationDistanceToPointStatic()
        {
            var actual = GeoPoint.CalculationDistanceToPoint(55.720224, 37.629893, 33.857982, 9.526866);

            Assert.AreEqual(expected: 5d, actual: actual);
        }

        [TestMethod]
        public void CalculationDistanceToPoint()
        {
            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: 3000, actual: actual, delta: 300);
        }
    }
}
