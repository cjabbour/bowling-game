using System;

namespace Bowling
{
    public static class Extensions
    {
        public static bool IsBetween<T>(this T value, T min, T max) where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0) return false;
            if (value.CompareTo(max) > 0) return false;
            return true;
        }

    }
}
