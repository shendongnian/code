    using System.Windows.Forms.Design;
    public class MyControlDesigner : ControlDesigner
    {
        public override SelectionRules SelectionRules
        {
            get
            {
                return SelectionRules.LeftSizeable |
                       SelectionRules.RightSizeable |
                       SelectionRules.Moveable;
            }
        }
    }
