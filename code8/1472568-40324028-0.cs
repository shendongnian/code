    public class MyCheckBox : CheckBox
    {
        protected override void OnClick(EventArgs e)
        {
            if (AutoCheck)
                switch (CheckState)
                {
                    case CheckState.Indeterminate:
                        CheckState = CheckState.Checked;
                        break;
                    case CheckState.Unchecked:
                        if (ThreeState)
                        {
                            CheckState = CheckState.Indeterminate;
                        }
                        else
                        {
                            CheckState = CheckState.Checked;
                        }
                        break;
                    default:
                        CheckState = CheckState.Unchecked;
                        break;
                }
            base.OnClick(e);
        }
    }
