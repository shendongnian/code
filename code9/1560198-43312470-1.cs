    class MyWrapperControl : SomeThirdPartyControl
    {
      public event MouseEventHandler AfterMouseDoubleClick;
      protected void override OnMouseDoubleClick(MouseEventArgs e)
      {
         base.OnMouseDoubleClick(e); //This will Do X.
    
         OnAfterMouseDoubleClick(e);
      }
      protected virtal void OnAfterMouseDoubleClick(MouseEventArgs e)
      {
           var temp = AfterMouseDoubleClick;
           if(temp != null)
               temp(this, e);
      }
    }
