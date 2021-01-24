    [DefaultEvent("ValueChanged")]
    [ComVisible(true)]
    [DefaultProperty("Value")]
    [DefaultBindingProperty("Value")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer("System.Windows.Forms.Design.DateTimePickerDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    public class NullableDateTimePicker : DateTimePicker
    {
        #region Externals
        private const int GWL_STYLE = (-16);
        private const int MCM_FIRST = 0x1000;
        private const int MCM_GETMINREQRECT = (MCM_FIRST + 9);
        private const int MCS_WEEKNUMBERS = 0x4;
        private const int DTM_FIRST = 0x1000;
        private const int DTM_GETMONTHCAL = (DTM_FIRST + 8);
        [DllImport("User32.dll")]
        public static extern int GetWindowLong(IntPtr h, int index);
        [DllImport("User32.dll")]
        public static extern int SetWindowLong(IntPtr h, int index, int value);
        [DllImport("User32.dll")]
        private static extern IntPtr SendMessage(IntPtr h, int msg, int param, int data);
        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr h, int msg, int param, ref Rectangle data);
        [DllImport("User32.dll")]
        private static extern int MoveWindow(IntPtr h, int x, int y, int width, int height, bool repaint);
        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetParent(IntPtr hWnd);
        #endregion
        #region General
        public NullableDateTimePicker()
        {
            this.ShowCheckBox = true;
        }
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the date/time value assigned to the control.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// The set value is less than System.Windows.Forms.DateTimePicker.MinDate or more than System.Windows.Forms.DateTimePicker.MaxDate.
        /// </exception>
        [RefreshProperties(RefreshProperties.All)]
        [Bindable(true)]
        public new DateTime? Value
        {
            get
            {
                if (!base.Checked)
                {
                    return null;
                }
                return base.Value;
            }
            set
            {
                if (value.HasValue)
                {
                    base.Checked = true;
                    if (this.Format == DateTimePickerFormat.Short)
                    {
                        base.Value = value.Value.Date;
                    }
                    else if (this.Format == DateTimePickerFormat.Time)
                    {
                        base.Value = default(DateTime).Add(value.Value.TimeOfDay);
                    }
                    else
                    {
                        base.Value = value.Value;
                    }
                }
                else
                {
                    base.Checked = false;
                }
            }
        }
        /// <summary>
        /// Gets or sets whether to show week numbers.
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public bool ShowWeekNumbers
        {
            get;
            set;
        }
        #endregion
        #region Week numbers
        /// <summary>
        /// Raises the System.Windows.Forms.DateTimePicker.DropDown event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnDropDown(EventArgs e)
        {
            IntPtr monthView = SendMessage(this.Handle, DTM_GETMONTHCAL, 0, 0);
            int style = GetWindowLong(monthView, GWL_STYLE);
            if (this.ShowWeekNumbers)
            {
                style = style | MCS_WEEKNUMBERS;
            }
            else
            {
                style = style & ~MCS_WEEKNUMBERS;
            }
            Rectangle rect = new Rectangle();
            SetWindowLong(monthView, GWL_STYLE, style);
            SendMessage(monthView, MCM_GETMINREQRECT, 0, ref rect);
            MoveWindow(monthView, 0, 0, rect.Right + 3, rect.Bottom, true);
            //
            // Resize the surrounding window to let the new text fit
            //
            IntPtr parent = GetParent(monthView);
            Rectangle mainRect = new Rectangle();
            SendMessage(parent, MCM_GETMINREQRECT, 0, ref mainRect);
            MoveWindow(parent, 0, 0, mainRect.Right + 6, mainRect.Bottom + 6, true);
            base.OnDropDown(e);
        }
        #endregion
    }
