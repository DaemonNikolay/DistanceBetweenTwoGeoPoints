using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DistanceBetweenTwoGeoPoints
{
    public class GeoPoint
    {
        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        private double Latitude { get; set; }
        private double Longitude { get; set; }

        public double CalculationDistanceToPoint(GeoPoint second)
        {
            return double.MinValue;
        }

        public static double CalculationDistanceToPoint(double firstStart, double firstEnd, double secondStart, double secondEnd)
        {
            return double.MinValue;
        }
    }
}