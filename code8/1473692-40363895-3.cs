        public static Vector3 Normalize(Vector3 value)
        {
            float single = Vector3.Magnitude(value);
            if (single <= 1E-05f)
            {
                return Vector3.zero;
            }
            return value / single;
        }
