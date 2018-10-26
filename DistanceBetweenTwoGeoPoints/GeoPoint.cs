using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DistanceBetweenTwoGeoPoints
{
    public class GeoPoint
    {
        private const double RadiusEarthKM = 6371;

        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        private double Latitude { get; set; }
        private double Longitude { get; set; }

        public static double CalculationDistanceToPoint(double firstStart, double firstEnd, double secondStart, double secondEnd)
        {


            return double.MinValue;
        }

        public double CalculationDistanceToPoint(GeoPoint second)
        {
            if (!IsCorrectGeoPoint(second) && !IsCorrectLatitude(Latitude) && !IsCorrectLongitude(Longitude))
            {
                return double.MinValue;
            }

            var deltaLatitude = ToRadian(second.Latitude - Latitude);
            var deltaLongitude = ToRadian(second.Longitude - Longitude);

            var a = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                    Math.Cos(ToRadian(Latitude)) * Math.Cos(ToRadian(second.Latitude)) *
                    Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2);

            var angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return RadiusEarthKM * angle;
        }

        private static bool IsCorrectGeoPoint(GeoPoint geoPoint)
        {
            return Math.Abs(geoPoint.Latitude) <= 90d && Math.Abs(geoPoint.Longitude) <= 180d;
        }

        private static bool IsCorrectLatitude(double latitude) => Math.Abs(latitude) <= 90d;

        private static bool IsCorrectLongitude(double longitude) => Math.Abs(longitude) <= 180d;

        private static double ToRadian(double deg) => deg == 0d ? 0d : deg * Math.PI / 180;
    }
}