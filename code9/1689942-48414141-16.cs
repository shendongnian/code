    try 
    {
        if (!Path.IsReadOnlyFileSystem(fileIWantToCreate))
        {
            using(var sw = new StreamWriter(fileIWantToCreate))
            {
                //fill file here
            }
        }
    }
    catch(  )
    {
        // handle the exception here
    }
