        private void TimerElapsed(object obj)
        {
            string dataToProcess = null;
            var list = new List<string>();
            while (_queue.TryDequeue(out dataToProcess))
            {
                list.Add(dataToProcess);
            }
            // Now you've got a list.
        }
