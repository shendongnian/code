       var blackCount = Controls
         .OfType<Stone>()
         .Count(stone => stone.getPen().Color == System.Drawing.Color.Black);
    
       if (blackCount == 1) {
         ...
       }
