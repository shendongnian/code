    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ModernUISample.metro
    {
        /// <summary>
        /// Menustrip for ModernUI-GUIs
        /// </summary>
        public class MetroMenuStrip : System.Windows.Forms.MenuStrip
        {
            /// <summary>
            /// Constructor
            /// </summary>
            public MetroMenuStrip()
                : base()
            {
                Renderer = new metroToolStripRenderer();
                Font = MetroUI.Style.BaseFont;
                ForeColor = MetroUI.Style.ForeColor;
            }
    
            /// <summary>
            /// OnItemAdded-Event we adjust the font and forecolor of this item
            /// </summary>
            /// <param name="e"></param>
            protected override void OnItemAdded(System.Windows.Forms.ToolStripItemEventArgs e)
            {
                base.OnItemAdded(e);
    
                e.Item.Font = MetroUI.Style.BaseFont;
                e.Item.ForeColor = MetroUI.Style.ForeColor;
            }
        }
    }
