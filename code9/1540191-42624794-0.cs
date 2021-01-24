    private void Symbol_OnSymbolDraw(object sender, SymbolDrawEventArgs e)
    {
      if (e.Series != null)
      {
        tChart1.Graphics3D.Brush.Color = e.Series.Color;
      }
      tChart1.Graphics3D.Rectangle(e.Rect);
    }
