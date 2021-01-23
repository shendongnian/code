    public class SpecializedCharInserter : CharInserter
    {
         internal override CharInsertionResult InsertString(string stringToInsert, int xStart, int yStart)
         {
                CharInsertionResult result = base.InsertString(stringToInsert, xStart, yStart);
                switch(result)
                {
                     case CharInsertionResult.NoRoom:
                          // Do stuff here to handle this scenario
                          break;
    
                     default:
                          return result;
                }
         }
    }
