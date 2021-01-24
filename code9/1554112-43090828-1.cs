    var isFileDownloaded = false;
    var tryCount = 0;
    while (tryCount++ < MAX_TRY_COUNT && !isFileDownloaded) {
         using (WebClient webClient = new WebClient())
         try{
             //do stuff here
             isFileDownloaded = true
         }catch //log exception and Thread.Sleep
    }
    if (isFileDownloaded){
    //        update progress
    } else{
    //too many retries, exit app
    }
