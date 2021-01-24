    try
    {
        ...
        int pos=myStream.Position;
        var fields=parser.ReadFields();
        if (!fieldsOK(fields))
        {
            myStream.Seek(pos);
            var errorLine=parser.ReadLine();
            //Log it
        }
    }
    catch(MalformedLineException exc)
    {
        var errorLine=parser.ErrorLine;
        //Log it
    }
