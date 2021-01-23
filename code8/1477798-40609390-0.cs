        public static void Free()
        {
            lock (lockobj)
            {
                foreach (var t in _timers)
                    t.Dispose();
                _timers.Clear();
            }
            lock (lockobj2)
            {
                foreach (var key in _timers2.Keys.ToList())
                    ClearInterval(key);
            }
        }
