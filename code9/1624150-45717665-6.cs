    for (int a = 0; a < linesArr.Length; a++)
         {
            if (s.Contains(citation))
            {
               matchedList.Add(linesArr[a]); //matched
               LineBeingEdited = a;
               break; //breaks the loop when a match is found
            }
         }
