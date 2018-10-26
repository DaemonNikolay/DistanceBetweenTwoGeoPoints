using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistanceBetweenTwoGeoPoints;

namespace Tests
{
    [TestClass]
    public class GeoPointTests
    {
        const double delta = 300;

        [TestMethod]
        public void CalculationDistanceToPointMoskauToTunis()
        {
            var moskau = new GeoPoint(55.720224, 37.629893);
            var tunis = new GeoPoint(33.857982, 9.526866);

            var actual = moskau.CalculationDistanceToPoint(tunis);

            Assert.AreEqual(expected: 3000, actual: actual, delta: delta, message: "Distance from Moskau to Tunis");
        }

        [TestMethod]
        public void CalculationDistanceToPointNewYorkToUrugvay()
        {
            var newYork = new GeoPoint(40.687512, -73.874631);
            var urugvay = new GeoPoint(-32.802743, -55.535703);

            var actual = newYork.CalculationDistanceToPoint(urugvay);

            Assert.AreEqual(expected: 8351, actual: actual, delta: delta, message: "Distance from New York to Urugvay");
        }

        [TestMethod]
        public void CalculationDistanceToPointNewYorkToWashington()
        {
            var newYork = new GeoPoint(40.687512, -73.874631);
            var washington = new GeoPoint(38.863545, -76.965959);

            var actual = newYork.CalculationDistanceToPoint(washington);

            Assert.AreEqual(expected: 328, actual: actual, delta: delta, message: "Distance from New York to Washington");
        }

        [TestMethod]
        public void CalculationDistanceToPointGabonToalKharga()
        {
            var gabon = new GeoPoint(-0.556921, 11.354516);
            var alKharga = new GeoPoint(25.506751, 29.339873);

            var actual = gabon.CalculationDistanceToPoint(alKharga);

            Assert.AreEqual(expected: 3500, actual: actual, delta: delta, message: "Distance from Gebon to alKharga");
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
    }
}
