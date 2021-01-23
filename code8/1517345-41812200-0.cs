        try
        {
           // ...
        }
        catch (PathTooLongException e)
        {
           _MaxPath = -2;
           return;
        }
        catch (Exception e) //anything else
        {
           _MaxPath = -1;
           // ...
        }
        finally 
        {
           // ...
        }
