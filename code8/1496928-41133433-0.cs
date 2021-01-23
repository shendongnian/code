    async Task TaskDelay()
    {
        await Task.Delay(2000);
    } 
    void main()
    {
        // Console.WriteLine etc. etc
        await PutTaskDelay();
        MessageBox.Show("Hello, I'm done waiting.");
    }
