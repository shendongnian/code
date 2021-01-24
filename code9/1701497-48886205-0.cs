        private IEnumerable<IEnumerable<T>> Split<T>(List<T> list)
        {
            int chunkSize;
            if (list.Count() > _maxChunkSize * _maxSendingThreads )
            {
                //We know that we can't get lett then 8 chunks of maxumum, so we will use maxumum chunk size
                chunkSize = 1000;
            }
            else
            {
                //Get the exact number of needed chunksize needed, then round up to nearest 50
                chunkSize = (int) (Math.Ceiling(list.Count / _maxSendingThreads / 50.0) * 50.0);
                if (chunkSize < 250)
                {
                    chunkSize = 250;
                }
            }
            var sections = (int) Math.Ceiling((double) list.Count / chunkSize);
            int i = 0;
            IEnumerable<IEnumerable<T>> splits = list.GroupBy(item => i++ % sections).Select(part => part.AsEnumerable());
            return splits;
        }
