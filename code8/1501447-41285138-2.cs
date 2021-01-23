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
        private Color inactiveColor = ControlPaint.Dark(SystemColors.Grad
