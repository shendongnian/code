    public void MessMessageSender(List<Message> messages)
    {
        try
        {
            var parallelOptions = new ParallelOptions();
            _cancelToken = new CancellationTokenSource();
            parallelOptions.CancellationToken = _cancelToken.Token;
            var maxProc = System.Environment.ProcessorCount;
            // this option use around 75% core capacity
            parallelOptions.MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(maxProc * 0.75));
            // the following option use all cores expect 1
            //parallelOptions.MaxDegreeOfParallelism = maxProc - 1;
            try
            {
                Parallel.ForEach(messages, parallelOptions, message =>
                {
                    try
                    {
                        Send(message);
                        //_logger.Info($"Successfully sent {text.Title}.");
                    }
                    catch (Exception ex)
                    {
                        //_logger.Error($"Something went wrong {ex}.");
                    }
                });
            }
            catch (OperationCanceledException e)
            {
                //User has cancelled this request.
            }
        }
        finally
        {
            //What ever dispose of clients;
        }
    }
