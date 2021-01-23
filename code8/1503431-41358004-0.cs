    private void Update_ViewModel_ShowMessage(global::System.Boolean obj, int phase)            
    {
      ...
      this.Update_ViewModel_ShowMessage_Cast_ShowMessage_To_Visibility(
        obj ? global::Windows.UI.Xaml.Visibility.Visible 
            : global::Windows.UI.Xaml.Visibility.Collapsed
       , phase);
    ...
    }
