     class CallbackClass<T>
            {
                private TaskCompletionSource<T> task = new TaskCompletionSource<T>();
    
                public void RequestData()
                {
                   
                }
    
                public void OnDataReturned(T data)
                {
                    task.SetResult(data);
                }
    
                public Task<T> Task { get { return task.Task; } }
            }
    
            class MyWrapperClass
            {
                public Task<DataObject> GetData()
                {
                    var cls = new CallbackClass<DataObject>();
    
                    cls.RequestData();
    
                    return cls.Task;
                }
            }
