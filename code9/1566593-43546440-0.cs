        [DefaultValue(typeof(Unit), "")]
        [WebCategory("Layout")]
        [WebSysDescription("WebControl_Width")]
        public virtual Unit Width
        {
            get
            {
                if (!this.ControlStyleCreated)
                {
                    return Unit.Empty;
                }
                return this.ControlStyle.Width;
            }
            set
            {
                this.ControlStyle.Width = value;
            }
        }
