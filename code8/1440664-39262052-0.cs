    public static void Check(string stringy)
        {
            int gender = 0;
            string[] arrayexample = { "Example One Male", "Example Two Female" };
            for(int I=0;i<arrayexample.Length;i++)
            {
              if (arrayexample[i].Contains(stringy))
              {
                int arrayPosition = i; //part that doesn't work
              }
            }
        }
