    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using System.Drawing;
    using System.Collections.Generic;
    
    namespace u4sSearchBox
    {
        [ToolboxBitmap(typeof(DataGrid))]
        public partial class u4sSearchBox : UserControl
        {
            DisplaySettings displaySettings = new DisplaySettings();
    
            #region "Constructor"
            public u4sSearchBox()
            {
                InitializeComponent();
            }
            #endregion
    
            #region "Display Settings"
            [Browsable(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Category("u4sSearchBox")]
            public DisplaySettings Display
            {
                get
                {
                    tsbAdd.Visible = displaySettings.AllowAdd;
                    tsbEdit.Visible = displaySettings.AllowEdit;
                    tsbDelete.Visible = displaySettings.AllowDelete;
                    tsbAdvSearch.Visible = displaySettings.AllowAdvSearch;
                    tssbPrint.Visible = displaySettings.AllowPrint;
                    tssbExport.Visible = displaySettings.AllowExport;
                    if (!displaySettings.AllowAdd && !displaySettings.AllowEdit && !displaySettings.AllowDelete) { tss1.Visible = false; } else { tss1.Visible = true; }
                    if (!displaySettings.AllowPrint && !displaySettings.AllowExport) { tss3.Visible = false; } else { tss3.Visible = true; }
                    return this.displaySettings;
                }
    
                set
                {
                    this.displaySettings = value;
                }
            }
            #endregion
    	}
    }
