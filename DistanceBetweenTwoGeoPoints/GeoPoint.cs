using System;

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

        public static double CalculationDistanceToPoint(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
        {
            if (!IsCorrectGeoPoints(firstLatitude, firstLongitude, secondLatitude, secondLongitude))
            {
                return double.MinValue;
            }

            var deltaLatitude = ToRadian(secondLatitude - firstLatitude);
            var deltaLongitude = ToRadian(secondLongitude - firstLongitude);

            var a = Math.Sin(deltaLatitude / 2) * Math.Sin(deltaLatitude / 2) +
                    Math.Cos(ToRadian(firstLatitude)) * Math.Cos(ToRadian(secondLatitude)) *
                    Math.Sin(deltaLongitude / 2) * Math.Sin(deltaLongitude / 2);

            var angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return RadiusEarthKM * angle;
        }

        public double CalculationDistanceToPoint(GeoPoint second)
        {
            if (second == null)
            {
                return double.MinValue;
            }

            return CalculationDistanceToPoint(Latitude, Longitude, second.Latitude, second.Longitude);
        }

        private static bool IsCorrectGeoPoints(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude)
        {
            if (IsCorrectLatitude(firstLatitude) && IsCorrectLongitude(firstLongitude))
            {
                if (IsCorrectLatitude(secondLatitude) && IsCorrectLongitude(secondLongitude))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsCorrectLatitude(double latitude)
        {
            if (Math.Abs(latitude) <= 90d)
            {
                return true;
            }

            return false;
        }

        private static bool IsCorrectLongitude(double longitude)
        {
            if (Math.Abs(longitude) <= 180d)
            {
                return true;
            }

            return false;
        }

        private static double ToRadian(double deg)
        {
            if (deg == 0d)
            {
                return 0d;
            }

            return deg * Math.PI / 180;
        }
    }
}