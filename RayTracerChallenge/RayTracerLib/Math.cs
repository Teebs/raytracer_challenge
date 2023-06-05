namespace RayTracerLib
{
    public static class Math
    {
        private static float EPSILON = 0.00001f;

        public static bool Equals(float a, float b)
        {
            return System.Math.Abs(a - b) < EPSILON ? true : false;
        }

        public static float SquareRoot(float number)
        {
            float root;
            float guess = number;

            while(true)
            {
                root = 0.5f * (guess + (number / guess));

                if ( System.Math.Abs(root - guess) < EPSILON )
                    break;

                guess = root;
            }

            return root;
        }
    }
}
