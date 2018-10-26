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
            if (IsNotCorrectGeoPoint(second) && IsNotCorrectLatitude(Latitude) && IsNotCorrectLongitude(Longitude))
            {
                return double.MinValue;
            }

            var firstLatitude = ToRadian(Latitude);
            var firstLongitude = ToRadian(Longitude);
            var secondLatitude = ToRadian(second.Latitude);
            var secondLongitude = ToRadian(second.Longitude);

            return double.MinValue;
        }



        public static double CalculationDistanceToPoint(double firstStart, double firstEnd, double secondStart, double secondEnd)
        {
            return double.MinValue;
        }

        private static double ToRadian(double deg) => deg == 0d ? 0d : Math.PI / 180 * deg;
        private static bool IsNotCorrectLongitude(double longitude) => Math.Abs(longitude) <= 180d;

        private static bool IsNotCorrectLatitude(double latitude) => Math.Abs(latitude) <= 90d;

        private static bool IsNotCorrectGeoPoint(GeoPoint geoPoint)
        {
            return Math.Abs(geoPoint.Latitude) <= 90d && Math.Abs(geoPoint.Longitude) <= 180d;
        }
    }
}