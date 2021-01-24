    GMarkerArrow marker1 = new GMarkerArrow(new PointLatLng(-30, -40));
                marker1.ToolTipText = "blablabla";
                marker1.ToolTip.Fill = Brushes.Black;
                marker1.ToolTip.Foreground = Brushes.White;
                marker1.ToolTip.Stroke = Pens.Black;
                marker1.Bearing = 30; // Rotation angle
                marker1.Fill = new SolidBrush(Color.FromArgb(155, Color.Blue)); // Arrow color
                markers.Markers.Add(marker1);
                gMapControl1.Overlays.Add(markers);
