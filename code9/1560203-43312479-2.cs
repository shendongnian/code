    class MyControl:SomeControl
    {
      public event MouseButtonEventHandler AfterMouseDoubleClick;
      void override OnMouseDoubleClick(MouseEventArgs e)
      {
         base.OnMouseDoubleClick(e)
         //call event handlers
         OnAfterMouseDoubleClick(e)
      }
      void virtual OnAfterMouseDoubleClick(MouseEventArgs e)
      {
         if(AfterMouseDoubleClick != null)
           AfterMouseDoubleClick(this, e)
      }
    }
