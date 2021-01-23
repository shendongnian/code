    using(FileStream sourceStream = File.Open(sourceFileName, FileMode.Open))
    {
        using(FileStream destinationStream = File.Create(destinationFileName))
        {
            try
            {
                await sourceStream.CopyToAsync(destinationStream);
                // The sourceFileName file is locked since you are inside the 
                // the using statement. Move statement for deleting file to
                // outside the using.
                File.Delete(sourceFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    // Move it here
