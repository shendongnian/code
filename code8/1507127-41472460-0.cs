    // using System.Threading.Tasks;
    public HttpResponseMessage process(string image) {
    
       var downloadTask = Task.Run(() => {
           DownloadFromBlob(image);
    	});
    	
       DoSomeSetup();  
    
       downloadTask.Wait();
    
       return DrawTextOnImage();
    }
