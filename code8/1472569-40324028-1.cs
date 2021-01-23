      public class MyCheckBox : CheckBox
      {
        protected override void OnClick(EventArgs e)
        {
        // base.OnClick(e) will change the value of CheckState based on
        // the current value. For this custom version the desired outcome
        // is to reverse the normal order of the checkBox changes
        // Normal order is Unchecked -> Checked -> Indeterminate
        // Desired order is Indeterminate -> Checked -> Unchecked
        // The trick is to set the CheckState to the state of the 
        // state before the normal order so that when base.OnClick does
        // its thing we have our desired result
        if (AutoCheck) {
          switch (CheckState) {
            case CheckState.Indeterminate:
              CheckState = CheckState.Unchecked; //Becomes Checked
              break;
            case CheckState.Checked:
              CheckState = CheckState.Indeterminate; //Becomes Unchecked
              break;
            default: // Unchecked
              if (ThreeState) {
                CheckState = CheckState.Checked; //Becomes Indeterminate
              }
              // If not ThreeState normal toggle applies
              break;
          }
        }
        base.OnClick(e);
      }
