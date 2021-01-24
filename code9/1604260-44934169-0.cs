    using System;
    using System.Windows.Forms;
    
    namespace ConsistentControls
    {
        public class ConsistentToolStripButton : ToolStripButton
        {
            public override System.Windows.Forms.ToolStripItemDisplayStyle DisplayStyle
            {
                get
                {
                    return base.DisplayStyle;
                }
                set
                {
    
                }
            }
    
            public ConsistentToolStripButton()
            {
                base.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            }
        }
    }
