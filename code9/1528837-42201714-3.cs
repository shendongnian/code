    unsafe double CallGetAreaPointers(Point[] vertices, bool isClosed)
    {
      var ipArray = Marshal.AllocHGlobal(vertices.Length * sizeof(Point));
      var ipItems = new Stack<IntPtr>();
      
      try
      {
        Point** pArray = (Point**)ipArray.ToPointer();
        
        for (var i = 0; i < vertices.Length; i++)
        {
          var ipItem = Marshal.AllocHGlobal(sizeof(Point));
          ipItems.Push(ipItem);
          
          Marshal.StructureToPtr(vertices[i], ipItem, false);
          
          pArray[i] = (Point*)ipItem.ToPointer();
        }
        
        GetArea(pArray, vertices.Length, isClosed);
      }
      finally
      {
        IntPtr ipItem;
        while ((ipItem = ipItems.Pop()) != IntPtr.Zero) Marshal.FreeHGlobal(ipItem);
      
        Marshal.FreeHGlobal(ipArray);
      }
    }
