     if ((comboBox1.Text != defaultTextShape) && (comboBox2.Text != defaultTextColour))
            {
                Brush b;
                switch (comboBox1.Text)
                {
                    case "Red"   : b = Brushes.Red; break;
                    case "Green" : b = Brushes.Green; break;
                    case "Blue"  : b = Brushes.Blue; break;
                    default      : b = new SolidBrush(CustomColour); break;
                }
                switch (comboBox2.Text)
                {
                    case "Rectangle": e.Graphics.FillRectangle(b, new Rectangle(105, 120, 75, 50)); break;
                    case "Circle"   : e.Graphics.FillEllipse(b, new Rectangle(105, 120, 64, 64)); break;                    
                    default:
                        Point[] points = { new Point(140, 110), new Point(230, 190), new Point(50, 190) };
                        e.Graphics.FillPolygon(b, points); break;
                }
                
            }
