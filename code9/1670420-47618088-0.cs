    public static class RandomColorGenerator
    {
        public static Color GetNextPseudoRandomColor(Color current)
        {
            int keep = new System.Random().Next(0, 2);
            float red = UnityEngine.Random.Range(0f, 1f);
            float green = UnityEngine.Random.Range(0f, 1f);
            float blue = UnityEngine.Random.Range(0f, 1f);
            Color c = new Color(red, green, blue);
            float fixedComp = c[keep] + 0.5f;
            c[keep] = fixedComp - Mathf.Floor(fixedComp);
            return c;
        }
    }
