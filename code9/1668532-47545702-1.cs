    StreamReader Reader = null;
    string FilePath = "Your File Path";
    try
    {
      Reader = new StreamReader(FilePath);
      while(Reader.Peek() > 0)
      {
        string line = Reader.ReadLine();
        bool HeaderFound = false;
        if(line == "What ever your headers are")
        {
          HeaderFound = true;
        }
        if(HeaderFound)
        {
          //Here is all your data you were looking for.
         //Do whatever you need to do with it now.
        }
      }
    } catch(exception e)
    {/*Deal with the issues*/}
    finally
    {
      if(Reader != null)
      {
        Reader.Close();
        Reader.Dispose();
      }
    }
 
