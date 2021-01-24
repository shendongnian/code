      int bodiesCount = Part.HybridShapeFactory.Parent.Bodies.count
      for (int i = 1; i <= bodiesCount; i++)
      {
         string name = Part.HybridShapeFactory.Parent.Bodies.Item(i).Name;
         if(name == TextBox.Text("your string value"))
         {
            Sel.Add(Part.HybridShapeFactory.Parent.Bodies.Item(i));
            MessageBox.Show(i.ToString() + " : " + name);
         }
         
      }
