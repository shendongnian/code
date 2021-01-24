    public static class ListExts {
        public static List<Tnew> ConvertAll<Told, Tnew>(this List<Told> src, Func<Told, Tnew> fconv) {
            var ans = new List<Tnew>(src.Count);
            for (int j1 = 0; j1 < src.Count; ++j1)
                ans.Add(fconv(src[j1]));
            return ans;
        }
    }
