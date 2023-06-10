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

        public static Tuple operator -(Tuple original)
        {
            Tuple negation = new Tuple()
            {
                X = -original.X,
                Y = -original.Y,
                Z = -original.Z,
                W = original.W
            };

            return negation;
        }

        public static Tuple operator *(Tuple original, float multiplier)
        {
            Tuple multiplied = new Tuple()
            {
                X = original.X * multiplier,
                Y = original.Y * multiplier,
                Z = original.Z * multiplier,
            };

            return multiplied;
        }

        public static Tuple operator /(Tuple original, float diviser)
        {
            Tuple result = new Tuple()
            {
                X = original.X / diviser,
                Y = original.Y / diviser,
                Z = original.Z / diviser,
            };

            return result;
        }

        public float Magnitude()
        {
            return Math.SquareRoot(X * X + Y * Y + Z * Z + W * W) ;
        }

        public Tuple Normalize()
        {
            var magnitude = Magnitude();

            var normalizedVector = new Tuple()
            {
                X = X / magnitude,
                Y = Y / magnitude,
                Z = Z / magnitude,
                W = W / magnitude
            };

            return normalizedVector;
        }

        public bool IsPoint()
        {
            return Math.Equals(W, 1.0f);
        }

        public bool IsVector()
        {
            return Math.Equals(W, 0.0f);
        }

        public float DotProduct(Tuple v)
        {
            return this.X * v.X + this.Y * v.Y + this.Z * v.Z + this.W * v.W;
        }

        public Tuple CrossProduct(Tuple v)
        {
            return Tuple.Vector(Y * v.Z - Z * v.Y, Z*v.X - X*v.Z, X * v.Y - Y*v.X);
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