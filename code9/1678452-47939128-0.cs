    protected override void OnPaint(PaintEventArgs pe)
    {
      base.OnPaint(pe);
      if (this.Focused)
      {
        var rc = this.ClientRectangle;
        rc.Inflate(-2, -2);
        pe.Graphics.DrawRectangle(Pens.Black, rc);
      }
    }
