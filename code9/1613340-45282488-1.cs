    using (WebResponse response = await webReq.GetResponseAsync())
    
                // The previous statement abbreviates the following two statements. 
    
                //using (WebResponse response = await responseTask)
                {
                    // Get the data stream that is associated with the specified url. 
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        // Read the bytes in responseStream and copy them to content. 
                        await responseStream.CopyToAsync(content);
    
                        // The previous statement abbreviates the following two statements. 
    
                        // CopyToAsync returns a Task, not a Task<T>. 
                        //Task copyTask = responseStream.CopyToAsync(content); 
    
                        // When copyTask is completed, content contains a copy of 
                        // responseStream. 
                        //await copyTask;
                    }
                }
