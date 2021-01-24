    private void threadJob()
    {
        while (true)
        {
            lock (threadLock)
            {
                if (_counter >= txtSearchTerms.Lines.Length)
                    return;
                Console.WriteLine(txtSearchTerms.Lines[_counter]);
                _counter++;
            }
        }
    }
