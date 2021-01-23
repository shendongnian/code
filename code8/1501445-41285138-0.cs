    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.ComponentModel;
    public class AdonaiOvalButton : Panel
    {
        bool isControlActive = false;
        #region Text
        private string text = "Button";
        [NotifyParentProperty(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [Description("Sets the Text"), Category("Adonai")]
        public override string Text
        {
            get { return text; }
            set
            {
                if (value != text)
                {
                    if (value == string.Empty)
                    { value = " "; }
                    text = value;
                    this.Invalidate();
                }
            }
        }
        #endregion Text
        #region ForeColor
        private Color foreColor = Color.White;
        [Description("Sets the Forecolor"), Category("Adonai")]
        public override Color ForeColor
        {
            get { return foreColor; }
            set
            {
                if (foreColor != value)
                {
                    foreColor = value;
                    this.Invalidate();
                }
            }
        }
        #endregion ForeColor
        #region Outline Color
        private Color outLineColor = Color.DarkGray;
        [Description("Sets the Buttons outline color"), Category("Adonai")]
        public Color OutLineColor
        {
            get { return outLineColor; }
            set
            {
                if (outLineColor != value)
                {
                    outLineColor = value;
                    this.Invalidate();
                }
            }
        }
        #endregion Outline Color
        #region Outline Width
        private float outlineWidth = 0.4f;
        [Description("Sets the Buttons outline width"), Category("Adonai")]
        public float OutlineWidth
        {
            get { return outlineWidth; }
            set
            {
                if (outlineWidth != value)
                {
                    outlineWidth = value;
                    this.Invalidate();
                }
            }
        }
        #endregion Outline Width
        #region Default Back Color
        //--Default Button Color--//
        private Color inactiveColor = ControlPaint.Dark(SystemColors.GradientActiveCaption, 0.2f);
        [Description("Sets the Default Color"), Category("Adonai")]
        public Color InactiveColor
        {
            get { return inactiveColor; }
            set
            {
                if (inactiveColor != value)
                {
                    inactiveColor = value;
                    this.Invalidate();
                }
            }
        }
        #endregion Default Back Color
        #region Hover Back Color
        //--Hover Button Color--//
        private Color activeColor = Color.FromArgb(235, 235, 235);
        [Description("Sets the ending color"), Category("Adonai")]
        public Color HoverColor
        {
            get { return activeColor; }
            set
            {
                if (activeColor != value)
                    activeColor = value;
                this.Invalidate();
            }
        }
        #endregion Hover Back Color
        #region Font
        private Font font = new Font("Arial", 9f, FontStyle.Bold);
        //new Font("Arial", mainForm.lblName.Font.Size);
        //new Font(FontFamily.GenericSerif, 8.5f,FontStyle.Regular);
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Bindable(true)]
        [Description("Sets the Font of the button caption"), Category("Adonai")]
        public override Font Font
        {
            get { return font; }
            set
            {
                if (font != value)
                    font = value;
                this.Invalidate();
            }
        }
        #endregion Font
        #region Bend Radius
        private int radius = 20;
        [Description("Sets the Bend radius"), Category("Adonai")]
        public int Radius
        {
            get { return radius; }
            set
            {
                if (radius != value)
                    radius = value;
                this.Invalidate();
            }
        }
        #endregion Bend Radius
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public AdonaiOvalButton()
        {
            this.Size = new Size(106, 33);
            this.Resize += CustomPanel_Resize;
            this.Cursor = Cursors.Hand;
            //this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
        }
        void CustomPanel_Resize(object sender, EventArgs e)
        { this.Invalidate(); }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Color fillRoundColor;
            if (isControlActive)
            { fillRoundColor = activeColor; }
            else
            { fillRoundColor = inactiveColor; }
          //  g.FillRoundedRectangle(new SolidBrush(fillRoundColor), 2, 2, this.Width - 5, this.Height - 4, radius);
            g.FillRoundedRectangle(new SolidBrush(fillRoundColor), 3, 3, this.Width - 6, this.Height - 5, radius);
       
            Pen outline = new Pen(outLineColor, outlineWidth);
            g.DrawRoundedRectangle(outline, 3, 3, this.Width - 6, this.Height - 5, radius);
          
            Size textSize = TextRenderer.MeasureText(Text, Font);
            float presentFontSize = Font.Size;
            Font newFont = new Font(Font.FontFamily, presentFontSize, Font.Style);
            while ((textSize.Width > ClientRectangle.Width || textSize.Height > ClientRectangle.Height) && presentFontSize - 0.2F > 0)
            {
                presentFontSize -= 0.2F;
                newFont = new Font(Font.FontFamily, presentFontSize, Font.Style);
                textSize = TextRenderer.MeasureText(text, newFont);
            }
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            Color presentColor;
            if (isControlActive)
            { presentColor = inactiveColor; }
            else
            { presentColor = ForeColor; }
            SolidBrush sB = new SolidBrush(presentColor);
            g.DrawString(Text, newFont, sB, ClientRectangle, stringFormat);
            g.Dispose();
        }
       
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isControlActive = false;
            this.Invalidate();
        }
        protected override void OnMouseHover(EventArgs e)
        {
            base.OnMouseHover(e);
            isControlActive = true;
            this.Invalidate();
        }
        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            this.Invalidate();
        }
    }
