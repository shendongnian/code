    public static void deleteBlob(string name){
        //exist file
        int errCode = 0;
        if (FileExists(name, out errCode))
        {
                CloudBlockBlob blob = container.GetBlockBlobReference(name);
                blob.Delete();
                return;
        }
        //do something if error
    }
