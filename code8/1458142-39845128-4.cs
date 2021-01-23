    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Globalization;
    
    namespace TestSOF
    {
        [ToolboxBitmap(typeof(DataGrid))]
        public partial class myTextBox : UserControl
        {
            TextBoxTypeSettings textBoxTypeSettings = new TextBoxTypeSettings();
    
            public myTextBox()
            {
                InitializeComponent();
            }
    
            [Browsable(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Category("u4sSearchBox")]
            public TextBoxTypeSettings TextBoxType
            {
                get
                {
                    return this.textBoxTypeSettings;
                }
    
                set
                {
                    this.textBoxTypeSettings = value;
                }
            }
    
            private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
            {
                switch (textBoxTypeSettings.TextBoxMode)
                {
                    case TextBoxTypeSettings.Mode.AlphabetOnly:
                        e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
                        break;
                    case TextBoxTypeSettings.Mode.NumberOnly:
                        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                        {
                            e.Handled = true;
                        }
    
                        // only allow one decimal point
                        if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                        {
                            e.Handled = true;
                        }
                        break;
                }
            }
        }
    
        [TypeConverter(typeof(TextBoxTypeSettingsConverter))]
        public class TextBoxTypeSettings
        {
            private Mode _TextBoxMode;
    
            [Serializable]
            public enum Mode
            {
                NumberOnly,
                AlphabetOnly
            }
    
            [Browsable(true)]
            [Category("u4sSearchBox")]
            [DefaultValue("")]
            [Description("Gets and sets the textbox's mode")]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
            public Mode TextBoxMode
            {
                get
                {
                    return _TextBoxMode;
                }
                set
                {
                    _TextBoxMode = value;
                }
            }
        }
    
        public class TextBoxTypeSettingsConverter : ExpandableObjectConverter
        {
            // This override prevents the PropertyGrid from  
            // displaying the full type name in the value cell. 
            public override object ConvertTo(
                ITypeDescriptorContext context,
                CultureInfo culture,
                object value,
                Type destinationType)
            {
                if (destinationType == typeof(string))
                {
                    return "";
                }
    
                return base.ConvertTo(
                    context,
                    culture,
                    value,
                    destinationType);
            }
        }
    }
