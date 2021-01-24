    public bool Visible
    {
      get
      {
        return this.visible;
      }
      set
      {
        if (this.parent.AutoScroll || value == this.visible)
          return;
        this.visible = value;
        this.parent.UpdateStylesCore();
        this.UpdateScrollInfo();
        this.parent.SetDisplayFromScrollProps(this.HorizontalDisplayPosition, this.VerticalDisplayPosition);
      }
    }
