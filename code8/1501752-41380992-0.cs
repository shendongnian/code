    public class MyVisualStateManager : VisualStateManager
    {
        protected override bool GoToStateCore(Control control, FrameworkElement templateRoot, 
            System.String stateName, VisualStateGroup group, VisualState state, System.Boolean useTransitions)
        {
            switch (stateName)
            {
                case "NoIndicator":
                case "TouchIndicator":
                case "MouseIndicator":
                    base.GoToStateCore(control, templateRoot, "TouchIndicator", group, state, useTransitions);
                    break;
            }
            return true;
        }
    }
