    Task<int> download1 = await oClient.ProcessURLAsync(url, 
                  oWebClient, 
                  sParam).ContinueWith(
                      downloadTask =>{
    
                          if (downloadTask.Result == "success"){
                              var html = oClient.Post(
                                  "https://example.com" + "?" + sPostParameter,
                                  "");
                          } else{
                              //wait
                          }
                      });
