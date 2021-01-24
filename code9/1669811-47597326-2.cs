    //exeurl contains our updated executable url
    //downloadTo is where we want the executable to be downloaded to
    //prog is a progress reporter allowing you to keep track of current progress
    public static async Task<string> DownloadFileAsync(string exeurl, string downloadTo, IProgress<Tuple<long, long>> prog)
    {
        return await Task.Run(async () =>
        {
            //Create new client
            using (var client = new HttpClient())
            //Await the Get Response
            //HttpCompletionOption.ResponseHeadersRead allows us to process the headers before we actually
            //Download the file
            using (var response = await client.GetAsync(info.link, HttpCompletionOption.ResponseHeadersRead))
            //Get the content
            using (var responseContent = response.Content)
            {
                //Make sure that the directory exists
                if (!Directory.Exists(Path.GetDirectoryName(downloadTo)))
                {
                    //Create if it does not
                    Directory.CreateDirectory(Path.GetDirectoryName(downloadTo));
                }
                //A variable to allow us to report current progress
                long curLen = 0;
                //Now create the file
                using (var fStream = File.Create(downloadTo))
                //And start reading the stream async
                using (var hStream = await responseContent.ReadAsStreamAsync())
                {
                    //and get into a simple loop
                    while (true)
                    {
                        //Create a buffer to read the bytes in chunks from the stream
                        //(256 is just some example size, can be of any size you like)
                        byte[] buffer = new byte[256];
                        var readBytes = hStream.Read(buffer, 0, buffer.Length);
                        //if no bytes have been read, we are done
                        if (readBytes == 0)
                            break;
                        //write the buffer to the file
                        fStream.Write(buffer, 0, readBytes);
                        //append the ammount of read bytes to our current progress variable
                        curLen += readBytes;
                        //and report the progress to the callee
                        //responseContent.Headers.ContentLength.Value btw. contains the ContentLength reported by the server
                        prog.Report(new Tuple<long, long>(curLen, responseContent.Headers.ContentLength.Value));
                    }
                }
                return downloadTo;
            }
        });
    }
