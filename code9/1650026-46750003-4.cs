    foreach (string name2 in names1)
    {
           WebClient client = new WebClient();
           Uri imageurl = new Uri(name2);
           try
           {
                    
               client.DownloadFileAsync(imageurl, (@"C:\Users\Ramazan BIYIK\Desktop\HTML içerik\" + result+"\\" + i + ".jpg"));
               i++;
            }
               catch(Exception ex) {continue; }
    }
