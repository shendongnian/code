    StreamReader Reader = new StreamReader();
    string FilePath = "Your File Path";
    try
    {
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
      Reader.Close();
      Reader.Dispose();
    }
 
