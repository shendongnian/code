    public void PrintRandom() {
       Random r = new Random();
       // Decide how long the string will be
       int strLength = r.Next(1, 10);
       var sb = new StringBuilder();
       for (int i = 0; i < strLength; i++) {
          // Decide whether to post a number or letter
          int whichType = r.Next(0, 3);
          switch (whichType) {
            // Lower case letter
            case 0: sb.Append((char)(97 + r.Next(0, 26)));
              break;
            // Upper case letter
            case 1: sb.Append((char)(65 + r.Next(0, 26)));
               break;
            // Number
            case 2:
               sb.Append((char)(48 + r.Next(0, 10)));
               break;
          }
       }
       Console.WriteLine(sb.ToString());
       Console.ReadLine();
    }
