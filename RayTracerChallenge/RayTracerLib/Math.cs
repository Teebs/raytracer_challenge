namespace RayTracerLib
{
    public static class Math
    {
        private static float EPSILON = 0.00001f;

        public static bool Equals(float a, float b)
        {
            return System.Math.Abs(a - b) < EPSILON ? true : false;
        }
    }
}
