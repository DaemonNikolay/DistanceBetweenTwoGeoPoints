using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistanceBetweenTwoGeoPoints;

namespace Tests
{
    [TestClass]
    public class GeoPointTests
    {
        const double delta = 300;

        [TestMethod]
        public void CalculationDistanceToPointStaticMoskauToTunis()
        {
            const double latitudeMoskau = 55.720224;
            const double longitudeMoskau = 37.629893;
            const double latitudeTunis = 33.857982;
            const double longitudeTunis = 9.526866;

            var actual = GeoPoint.CalculationDistanceToPoint(latitudeMoskau, longitudeMoskau, latitudeTunis, longitudeTunis);

            Assert.AreEqual(expected: 3000, actual: actual, delta: delta);
        }

        [TestMethod]
        public void CalculationDistanceToPointMoskauToTunis()
        {
            var moskau = new GeoPoint(55.720224, 37.629893);
            var tunis = new GeoPoint(33.857982, 9.526866);

            var actual = moskau.CalculationDistanceToPoint(tunis);

            Assert.AreEqual(expected: 3000, actual: actual, delta: delta);
        }

        [TestMethod]
        public void CalculationDistanceToPointNewYorkToUrugvay()
        {
            var newYork = new GeoPoint(40.687512, -73.874631);
            var urugvay = new GeoPoint(-32.802743, -55.535703);

            var actual = newYork.CalculationDistanceToPoint(urugvay);

            Assert.AreEqual(expected: 8351, actual: actual, delta: delta);
        }

        [TestMethod]
        public void CalculationDistanceToPointStaticNewYorkToUrugvay()
        {
            var newYork = new GeoPoint(40.687512, -73.874631);
            var urugvay = new GeoPoint(-32.802743, -55.535703);

            var actual = newYork.CalculationDistanceToPoint(urugvay);

            Assert.AreEqual(expected: 8351, actual: actual, delta: delta);
        }
    }
}
