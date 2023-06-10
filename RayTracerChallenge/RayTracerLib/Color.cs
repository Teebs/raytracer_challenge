using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracerLib
{
    public struct Color
    {
        public float Red;
        public float Green;
        public float Blue;

        public Color(float red, float green, float blue)
        {
            Red = red;
            Green = green;
            Blue = blue; 
        }
        public static Color operator +(Color left, Color right)
        {
            Color sum = new Color()
            {
                Red = left.Red + right.Red,
                Green = left.Green + right.Green,
                Blue = left.Blue + right.Blue
            };

            return sum;
        }

        public static Color operator -(Color left, Color right)
        {
            Color diff = new Color()
            {
                Red = left.Red - right.Red,
                Green = left.Green - right.Green,
                Blue = left.Blue - right.Blue
            };

            return diff;
        }

        public static Color operator *(Color original, float multiplier)
        {
            Color multiplied = new Color()
            {
                Red = original.Red * multiplier,
                Green = original.Green * multiplier,
                Blue = original.Blue * multiplier
            };

            return multiplied;
        }

        public static Color operator *(Color left, Color right)
        {
            Color multiplied = new Color()
            {
                Red = left.Red * right.Red,
                Green = left.Green * right.Green,
                Blue = left.Blue * right.Blue 
            };

            return multiplied;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Color))
            {
                return false;
            }

            Color color = (Color)obj;
            return this == color;
        }

        public static bool operator ==(Color left, Color right)
        {
            return Math.Equals(left.Red, right.Red) &&
                Math.Equals(left.Green, right.Green) &&
                Math.Equals(left.Blue, right.Blue);
        }

        public static bool operator !=(Color left, Color right)
        {
            return !(left == right);
        }

    }
}
