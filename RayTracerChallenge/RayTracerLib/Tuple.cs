using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace RayTracerLib
{
    public struct Tuple
    {
        public float X;
        public float Y;
        public float Z;
        public float W;

        public Tuple(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null || obj.GetType() != typeof(Tuple))
            {
                return false;
            }

            Tuple tuple = (Tuple)obj;
            return this == tuple;
        }

        public static bool operator ==(Tuple left, Tuple right)
        {
            return Math.Equals(left.X, right.X) &&
                Math.Equals(left.Y, right.Y) &&
                Math.Equals(left.Z, right.Z) &&
                Math.Equals(left.W, right.W);
        }
        public static bool operator !=(Tuple left, Tuple right)
        {
            return !(left == right);
        }

        public static Tuple operator +(Tuple left, Tuple right)
        {
            Tuple sum = new Tuple()
            {
                X = left.X + right.X,
                Y = left.Y + right.Y,
                Z = left.Z + right.Z,
                W = left.W + right.W
            };

            return sum;
        }

        public static Tuple operator -(Tuple left, Tuple right)
        {
            Tuple diff = new Tuple()
            {
                X = left.X - right.X,
                Y = left.Y - right.Y,
                Z = left.Z - right.Z,
                W = left.W - right.W
            };

            return diff;
        }

        public bool IsPoint()
        {
            return Math.Equals(W, 1.0f);
        }

        public bool IsVector()
        {
            return Math.Equals(W, 0.0f);
        }

        public static Tuple Point(float x, float y, float z)
        {
            return new Tuple() { X = x, Y = y, Z = z, W = 1 };
        }

        public static Tuple Vector(float x, float y, float z)
        {
            return new Tuple() { X = x, Y = y, Z = z, W = 0 };
        }
    }
}