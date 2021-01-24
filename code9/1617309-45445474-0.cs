      foreach(var item in listBox1.Items)
      {
          // check if listbox2 contains the current item in the foreach loop.
          // don't forget to use: using System.Linq;
          bool hasItem = listBox2.Items.Contains(item);
   
           // if it has it than remove it
           if(hasItem)
              listBox2.Items.Remove(item);
       }
