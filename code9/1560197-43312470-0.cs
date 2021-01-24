    class MyWrapperControl : SomeThirdPartyControl
    {
      void override OnMouseDoubleClick(MouseEventArgs e)
      {
         base.OnMouseDoubleClick(e); //This will Do X.
    
         //Do Y
      }
    }
