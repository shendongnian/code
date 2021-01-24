    public class Transfer
    {
        public void GetData(ObservableCollection<int>data, CancellationToken cancellationToken)
        {
            while (true)
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        //Will throw OperationCanceledException if the operation was asked to be canceled
                        cancellationToken.ThrowIfCancellationRequested();
                        data.Add(d);
                    }
                }
            }
        }
    }
