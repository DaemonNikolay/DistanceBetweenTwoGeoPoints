using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistanceBetweenTwoGeoPoints;

namespace Tests
{
    [TestClass]
    public class GeoPointTests
    {
        const double delta = 0.3;


        [TestMethod]
        public void ManualFirst()
        {
            var first = new GeoPoint(0, 0);
            var second = new GeoPoint(0, 1);

            var actual = first.CalculationDistanceToPoint(second);

            Assert.AreEqual(expected: 111, actual: actual, delta: delta);
        }
        [TestMethod]
        public void ManualSecond()
        {
            var first = new GeoPoint(89.9, 0);
            var second = new GeoPoint(89.9, 1);

            var actual = first.CalculationDistanceToPoint(second);

            Assert.AreEqual(expected: 0.19, actual: actual, delta: 0.1);
        }


        [TestMethod]
        public void CalculationDistanceToPointMoskauToTunis()
        {
            var moskau = new GeoPoint(55.752890, 37.617308);
            var tunis = new GeoPoint(36.797794, 10.172916);

            var actual = moskau.CalculationDistanceToPoint(tunis);

            Assert.AreEqual(expected: 2944.8, actual: actual, delta: delta, message: "Distance from Moskau to Tunis");
        }

        [TestMethod]
        public void CalculationDistanceToPointNewYorkToUrugvay()
        {
            var newYork = new GeoPoint(40.687512, -73.874631);
            var urugvay = new GeoPoint(-32.802743, -55.535703);

            var actual = newYork.CalculationDistanceToPoint(urugvay);

            Assert.AreEqual(expected: 8385.8, actual: actual, delta: delta, message: "Distance from New York to Urugvay");
        }

        [TestMethod]
        public void CalculationDistanceToPointGabonToalKharga()
        {
            var gabon = new GeoPoint(-0.556921, 11.354516);
            var alKharga = new GeoPoint(25.506751, 29.339873);

            var actual = gabon.CalculationDistanceToPoint(alKharga);

            Assert.AreEqual(expected: 3483.4, actual: actual, delta: delta, message: "Distance from Gabon to AlKharga");
        }


        [TestMethod]
        public void CalculationDistanceToPointNotCorrectStartGeoPoints()
        {
            var start = new GeoPoint(555.72, 370.6);
            var end = new GeoPoint(-33.857, 9.526);

            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Not correct start geo point");
        }

        [TestMethod]
        public void CalculationDistanceToPointNotCorrectEndGeoPoints()
        {
            var start = new GeoPoint(33.857, 9.526);
            var end = new GeoPoint(-555.72, 370.6);

            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Not correct end geo point");
        }

        [TestMethod]
        public void CalculationDistanceToPointMinValue()
        {
            var start = new GeoPoint(double.MinValue, double.MinValue);
            var end = new GeoPoint(double.MinValue, double.MinValue);

            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Minimum value geo point");
        }

        [TestMethod]
        public void CalculationDistanceToPointMaxValue()
        {
            var start = new GeoPoint(double.MaxValue, double.MaxValue);
            var end = new GeoPoint(double.MaxValue, double.MaxValue);

            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Maximum value geo point");
        }

        [TestMethod]
        public void CalculationDistanceToPointZeroValue()
        {
            var start = new GeoPoint(0d, 0d);
            var end = new GeoPoint(0d, 0d);

            var actual = start.CalculationDistanceToPoint(end);

            Assert.AreEqual(expected: 0d, actual: actual, message: "Zero value geo point");
        }

        [TestMethod]
        public void CalculationDistanceToPointNull()
        {
            var start = new GeoPoint(0d, 0d);

            var actual = start.CalculationDistanceToPoint(null);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Null value geo point");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointMoskauToTunis()
        {
            const double moskauLat = 55.752890;
            const double moskauLon = 37.617308;
            const double tunisLat = 36.797794;
            const double tunisLon = 10.172916;

            var actual = GeoPoint.CalculationDistanceToPoint(moskauLat, moskauLon, tunisLat, tunisLon);

            Assert.AreEqual(expected: 2944.8, actual: actual, delta: delta, message: "Static method: distance from Moskau to Tunis");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointNewYorkToUrugvay()
        {
            const double newYorkLat = 40.687512;
            const double newYorkLon = -73.874631;
            const double urugvayLat = -32.802743;
            const double urugvayLon = -55.535703;

            var actual = GeoPoint.CalculationDistanceToPoint(newYorkLat, newYorkLon, urugvayLat, urugvayLon);

            Assert.AreEqual(expected: 8385.8, actual: actual, delta: delta, message: "Static method: distance from New York to Urugvay");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointGabonToalKharga()
        {
            const double gabonLat = -0.556921;
            const double gabonLon = 11.354516;
            const double alKhargaLat = 25.506751;
            const double alKhargaLon = 29.339873;

            var actual = GeoPoint.CalculationDistanceToPoint(gabonLat, gabonLon, alKhargaLat, alKhargaLon);

            Assert.AreEqual(expected: 3483.4, actual: actual, delta: delta, message: "Static method: distance from Gabon to AlKharga");
        }


        [TestMethod]
        public void StaticCalculationDistanceToPointNotCorrectStartGeoPoints()
        {
            const double startLat = 555.72;
            const double startLon = 555.72;
            const double endLat = -33.857;
            const double endLon = 9.526;

            var actual = GeoPoint.CalculationDistanceToPoint(startLat, startLon, endLat, endLon);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Static method: not correct start geo point");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointNotCorrectEndGeoPoints()
        {
            const double startLat = 33.857;
            const double startLon = 9.526;
            const double endLat = -555.72;
            const double endLon = 370.6;

            var actual = GeoPoint.CalculationDistanceToPoint(startLat, startLon, endLat, endLon);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Static method: not correct end geo point");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointMinValue()
        {
            const double startLat = double.MinValue;
            const double startLon = double.MinValue;
            const double endLat = double.MinValue;
            const double endLon = double.MinValue;

            var actual = GeoPoint.CalculationDistanceToPoint(startLat, startLon, endLat, endLon);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Static method: minimum value geo point");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointMaxValue()
        {
            const double startLat = double.MaxValue;
            const double startLon = double.MaxValue;
            const double endLat = double.MaxValue;
            const double endLon = double.MaxValue;

            var actual = GeoPoint.CalculationDistanceToPoint(startLat, startLon, endLat, endLon);

            Assert.AreEqual(expected: double.MinValue, actual: actual, message: "Static method: maximum value geo point");
        }

        [TestMethod]
        public void StaticCalculationDistanceToPointZeroValue()
        {
            const double startLat = 0d;
            const double startLon = 0d;
            const double endLat = 0d;
            const double endLon = 0d;

            var actual = GeoPoint.CalculationDistanceToPoint(startLat, startLon, endLat, endLon);

            Assert.AreEqual(expected: 0d, actual: actual, message: "Static method: zero value geo point");
        }
    }
}
