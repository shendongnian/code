    /*Here is the full code of new text box control.
    Inspired by the Post made by Mike Tomlinson and Ehtesham*/
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;
    namespace MyTxtBoxControl
    {
    public class extTextBox:TextBox
    {
    #region New Utilisable Variables
        const int WM_ENABLE = 0xa; //in vb &HA
        Color _foreColor;
        Color _foreColorDisabled;
        Boolean _ColorIsSaved = false;
        Boolean _settingColor = false;
		//included a default text
		//that will be shown when no text will be entered
        String _DefaultText = "Enter Text Here";
    #endregion
    #region Constructor of the new textbox control
        public extTextBox()
        {
            base.Text = this._DefaultText;
            this._foreColor = this.ForeColor;
            //My Text Control Box event handlers
            this.TextChanged += new EventHandler(onTextChanged);
            this.KeyPress += new KeyPressEventHandler(onKeyPress);
            this.LostFocus += new EventHandler(onTextChanged);
            this.VisibleChanged+=new EventHandler(onVisibleChanged);
        }
    #endregion
    #region Event Handler Methods
        protected void onTextChanged(object sender, EventArgs e)
            {
                if (!String.IsNullOrEmpty(this.Text))
                {
                    this.ForeColor = this._foreColor;
                }
                else
                {
                    this.TextChanged-=new EventHandler(onTextChanged);
                    base.Text = this._DefaultText;
                    this.TextChanged+=new EventHandler(onTextChanged);
                }
            }
            protected void onKeyPress(object sender, EventArgs e)
            {
                //Replaces empty text as the firt key will be pressed
                string strings = base.Text.Replace(this._DefaultText, string.Empty);
                this.TextChanged -= new EventHandler(onTextChanged);
                this.Text=strings;
                this.TextChanged += new EventHandler(onTextChanged);
            }
            protected void onVisibleChanged(object sender, EventArgs e)
            {
                if (!(this._ColorIsSaved & this.Visible))
                {
                    _foreColor = this.ForeColor;
                    _foreColorDisabled = this.ForeColor;
                    _ColorIsSaved = true;
                    if (!(this.Enabled))
                    {
                        this.Enabled = true; //Enable to initialize the property then
                        this.Enabled = false;//disabling 
                    }
                    setColor();
                }
            }
            protected override void OnForeColorChanged(EventArgs e)
            {
                base.OnForeColorChanged(e);
                if (!_settingColor)
                {
                    _foreColor = this.ForeColor;
                    setColor();
                }
            }
            protected override void OnEnabledChanged(EventArgs e)
            {
                base.OnEnabledChanged(e);
                setColor();
            }
    #endregion
    #region Setcolor method
            private void setColor()
            {
                if (_ColorIsSaved)
                {
                    _settingColor = true;
                    if (this.Enabled)
                    {
                        this.ForeColor = this._foreColor;
                    }
                    else
                    {
                        this.ForeColor = this._foreColorDisabled;
                    }
                    _settingColor = false;
                }
            }
    #endregion
    #region TextBox Encapsulation Parameter overriding 
            protected override CreateParams CreateParams
            {
                get
                {
                    CreateParams CP = default(CreateParams);
                    if (!this.Enabled)
                    {
                        this.Enabled = true;
                        CP = base.CreateParams;
                        this.Enabled = false;
                    }
                    else
                    {
                        CP = base.CreateParams;
                    }
                    return CP;
                }
            }
	#endregion
    #region supressing WM_ENABLE message
            protected override void WndProc(ref Message mesg)
            {
                switch (mesg.Msg)
                {
                    case WM_ENABLE:
                   // Prevent the message from reaching the control,
                   // so the colors don't get changed by the default procedure.
                        return;// <-- suppress WM_ENABLE message
                }
                base.WndProc(ref mesg);//system you can do the rest disable process
            }
    #endregion
    #region User Defined Properties
            ///<summery>
            ///Property to set Text
            ///</summery>
            [Browsable(true)]
            [Category("Properties")]
            [Description("Set TextBox Text")]
            [DisplayName("Text")]
            public new String Text
            {
                get
                {
                    //It is required for validation for TextProperty
                    return base.Text.Replace(this._DefaultText, String.Empty);
                }
                set
                {
                    base.Text = value;
                }
            }
            ///<summery>
            ///Property to get or Set Default text at Design/Runtime
            ///</summery>
            [Browsable(true)]
            [Category("Properties")]
            [Description("Set default Text of TextBox, it will be shown when no text will be entered by the user")]
            [DisplayName("Default Text")]
            public String DefaultText
            {
                get
                {
                    return this._DefaultText;
                }
                set
                {
                    this._DefaultText = value;
                    base.OnTextChanged(new EventArgs());
                }
            }
    #endregion
    }
}
