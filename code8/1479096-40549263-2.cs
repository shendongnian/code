     var model = new sampleModel
     {
         Array = new int[table.GetLength(0),table.GetLength(1)] 
     };
     for (int i = 0; i <table.GetLength(0); i++)
     {
         for (int j = 0; j <table.GetLength(1); j++)
         {
             model.Array[i, j] = table[i, j];
         }
     }
     return View(model);
 
