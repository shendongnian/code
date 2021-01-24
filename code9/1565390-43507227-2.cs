        public static void mppF()
            Parallel.ForEach(items, item =>
            {
                mpp.Add((item.Key.PadRight(45) + " | " + item.Value/* + Environment.NewLine*/));
            });
