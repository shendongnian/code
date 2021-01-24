    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColorTable())
        {
        }
    }
    public class MyColorTable : ProfessionalColorTable
    {
        public override Color ButtonCheckedGradientBegin
        {
            get { return ButtonPressedGradientBegin; }
        }
        public override Color ButtonCheckedGradientEnd
        {
            get { return ButtonPressedGradientEnd; }
        }
        public override Color ButtonCheckedGradientMiddle
        {
            get { return ButtonPressedGradientMiddle; }
        }
    }
