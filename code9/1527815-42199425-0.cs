    private void Points1_GetPointerStyle(CustomPoint series, GetPointerStyleEventArgs e)
    {
      if (e.ValueIndex % 4 == 0)
      {
        series.Pointer.HorizSize = 4;
        series.Pointer.VertSize = 4;
      }
      else
      {
        series.Pointer.HorizSize = 2;
        series.Pointer.VertSize = 2;
      }
    }
