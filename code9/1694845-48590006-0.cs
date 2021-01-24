        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetLocation()
        {
            return this.GetType().Assembly.Location;
        }
