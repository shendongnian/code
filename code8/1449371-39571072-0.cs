    points.Add(0, 4);
    points.Add(1, 3);  //more point add etc
    //connect to the GetPointerStyle event to modify specific Point Pointerstyle at runtime.
    points.GetPointerStyle += new Steema.TeeChart.Styles.CustomPoint.GetPointerStyleEventHandler(point_GetPointerStyle);
    }
    private void point_GetPointerStyle(Steema.TeeChart.Styles.CustomPoint series, Steema.TeeChart.Styles.GetPointerStyleEventArgs e)
    {
      if (e.ValueIndex == 2)
        e.Style = Steema.TeeChart.Styles.PointerStyles.Cross;
      else
        e.Style = Steema.TeeChart.Styles.PointerStyles.Circle;
    }
