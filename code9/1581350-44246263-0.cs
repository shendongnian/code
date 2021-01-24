     double label1Y = Curve.Points[i].Y; //LineItem
        TextObj txtObj1 = new TextObj(Column1.ToString() + "   " + label1Y.ToString("0.0"), 0, label1Y, ZedGraph.CoordType.XChartFractionYScale, ZedGraph.AlignH.Right, ZedGraph.AlignV.Center);
                          
                            txtObj1.FontSpec.Border.IsVisible = false;
                            txtObj1.FontSpec.Fill.IsVisible = false;
                            txtObj1.FontSpec.Size = 5f;
                            txtObj1.FontSpec.IsAntiAlias = true;
                            txtObj1.FontSpec.Angle = 0;
                            // MessageBox.Show(txtObj1.FontSpec.StringAlignment.ToString());
                            txtObj1.IsVisible = true;
                            //txtObj1.Location.
                            txtObj1.ZOrder = ZOrder.A_InFront;
    
                            //txtObj1.IsInFrontOfData(true);
                            chart2.GraphPane.GraphObjList.Add(txtObj1);
