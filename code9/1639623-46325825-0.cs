     static public string Print(this List<int> input)
     {   
         int i;
         string output = "";
         for (i = 0; i <  input.Count - 1; i++)
         {
             // missing plus here
             output += input[i].ToString() + ", ";
         }
         return output;
      }
