    private void ToggleNavigation() 
    {
       for(int i = 0; i < controls.Count; i++)
       {
         var control = controls[i];
         if (control is Navigation)
         {
            control.Visible = !control.Visible;
         }
       }
    }
