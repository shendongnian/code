    public void FooMethodAsync(FooDelegate fooDelegate)
    {
        Task.Run(() => {
            try
            {
                var result = FooMethod();
                fooDelegate(result);
            }
            catch
            {
                // Who cares?
            }
        });
    }
