    public void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(PageLoadAsync));
    }
     
    public async Task PageLoadAsync()
    {
        //perform your actions here, including calling async methods and awaiting their results
    
        Task<string> downloadTask = new WebClient().DownloadStringTaskAsync("http://www.example.com");
    
        TextBox1.Title = "We can do some actions while waiting for the task to complete";
    
        TextBox2.Title = await downloadTask;
    }
