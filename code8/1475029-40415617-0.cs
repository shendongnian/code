    class OperationResult<T>
    {
        List<T> ResultData {get; set;}
        string Error {get; set;}
        bool Success {get; set;}
    }
    class Consumer<T>
    {
        void Load(id)
        {
            OperationResult<T> res = _repository.GetSomeData<T>(id);
            if (!res.Success)
            {
                MessageBox.Show(DecorateMsg(res.Error));
                return;
            }
        }
    }
