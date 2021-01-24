    public class ExampleClass
    {
        public static void HideControl(Control control, bool hide)
        {
            if (control != null) control.Visible = !hide;
        }
    }
