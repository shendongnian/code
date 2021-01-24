    class Class1
    {
        private static Queue<Func<bool>> _oisQueue = new Queue<Func<bool>>();
        private async Task<bool> RunNextTask()
        {
            bool success = true;
            if (_oisQueue.Any())
            {
                success = await Task.Run(_oisQueue.First());
                _oisQueue.Dequeue();
            }
            return success;
        }
    }
