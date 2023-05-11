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