    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();
      if ( IsChecked )
      {
        VisualStateManager.GoToState(this, "Checked", true);
      }
      else
      {
        VisualStateManager.GoToState(this, "Unchecked", true);
      }
    }
