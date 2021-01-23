    //put this in a seperate file, client proxies are usually marked "partal" so you can 
    // add functions on like this and not have them erased when you regenerate.
    partial class YourClientProxy
    {
        public Task<DataTable> ProcessSomethingAsync(string Param1, int Param2)
        {
            return Task<DataTable>.Factory.FromAsync(this.BeginProcessSomething, this.EndProcessSomething, Param1, Param2, null);
        }
    }
