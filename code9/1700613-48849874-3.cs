    DefaultValue(AutoCompleteMode.None),
    SRDescription(SR.ComboBoxAutoCompleteModeDescr),
    Browsable(true), EditorBrowsable(EditorBrowsableState.Always)
    ]
    public AutoCompleteMode AutoCompleteMode {
        get {
            return autoCompleteMode;
        }
        set {
            //valid values are 0x0 to 0x3
            if (!ClientUtils.IsEnumValid(value, (int)value, (int)AutoCompleteMode.None, (int)AutoCompleteMode.SuggestAppend)) {
                throw new InvalidEnumArgumentException("value", (int)value, typeof(AutoCompleteMode));
            }
            if (this.DropDownStyle == ComboBoxStyle.DropDownList &&
                this.AutoCompleteSource != AutoCompleteSource.ListItems &&
                value != AutoCompleteMode.None) {
                throw new NotSupportedException(SR.GetString(SR.ComboBoxAutoCompleteModeOnlyNoneAllowed));
            }
            if (Application.OleRequired() != System.Threading.ApartmentState.STA) {
                throw new ThreadStateException(SR.GetString(SR.ThreadMustBeSTA));
            }
            bool resetAutoComplete = false;
            if (autoCompleteMode != AutoCompleteMode.None && value == AutoCompleteMode.None) {
                resetAutoComplete = true;
            }
            autoCompleteMode = value;
            SetAutoComplete(resetAutoComplete, true);
        }
    }
