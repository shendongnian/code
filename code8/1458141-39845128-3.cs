    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel;
    using System.Globalization;
    
    namespace u4sSearchBox
    {
        [TypeConverter(typeof(DisplaySettingsConverter))]
        public class DisplaySettings
        {
            private bool _IsAllowAdd = true;
            private bool _IsAllowEdit = true;
            private bool _IsAllowDelete = true;
            private bool _IsAllowPrint = true;
            private bool _IsAllowExport = true;
            private bool _IsAllowAdvSearch = true;
    
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Description("Gets and sets the visibility of the Add")]
            public bool AllowAdd
            {
                get
                {
                    return _IsAllowAdd;
                }
                set
                {
                    _IsAllowAdd = value;
                }
            }
    
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Description("Gets and sets the visibility of the Edit")]
            public bool AllowEdit
            {
                get
                {
                    return _IsAllowEdit;
                }
                set
                {
                    _IsAllowEdit = value;
                }
            }
    
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Description("Gets and sets the visibility of the Delete")]
            public bool AllowDelete
            {
                get
                {
                    return _IsAllowDelete;
                }
                set
                {
                    _IsAllowDelete = value;
                }
            }
    
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Description("Gets and sets the visibility of the Adv. Search")]
            public bool AllowAdvSearch
            {
                get
                {
                    return _IsAllowAdvSearch;
                }
                set
                {
                    _IsAllowAdvSearch = value;
                }
            }
    
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Description("Gets and sets the visibility of the Print")]
            public bool AllowPrint
            {
                get
                {
                    return _IsAllowPrint;
                }
                set
                {
                    _IsAllowPrint = value;
                }
            }
    
            [Browsable(true)]
            [NotifyParentProperty(true)]
            [EditorBrowsable(EditorBrowsableState.Always)]
            [Description("Gets and sets the visibility of the Export")]
            public bool AllowExport
            {
                get
                {
                    return _IsAllowExport;
                }
                set
                {
                    _IsAllowExport = value;
                }
            }
        }
    
        public class DisplaySettingsConverter : ExpandableObjectConverter
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
