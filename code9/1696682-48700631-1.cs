      int bodiesCount = Part.Bodies.count
      for (int i = 1; i <= bodiesCount; i++)
      {
         string name = Part.Bodies.Item(i).Name;
         if(name == TextBox.Text("your string value"))
         {
            Sel.Add(Part.Bodies.Item(i));
            MessageBox.Show(i.ToString() + " : " + name);
         }
         
      }
