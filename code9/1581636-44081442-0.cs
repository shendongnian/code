                Image img;
                img = new Image();
                img.Source = new BitmapImage(new Uri(@"/NexansOlexProcessTools;component/Images/canvasImages/BTrailerOnlyTypeA.png", UriKind.Relative));
                //Set Canvas vales - very important
                //Canvas.Left = "141" 
                //Canvas.Top = "116"
                Canvas.SetLeft(img, 150);
                Canvas.SetTop(img, 130);
                //set maouse events handlers for each item
                img.MouseMove += new MouseEventHandler(shape_MouseMove);
                img.MouseLeftButtonDown += new MouseButtonEventHandler(shape_MouseLeftButtonDown);
                img.MouseLeftButtonUp += new MouseButtonEventHandler(shape_MouseLeftButtonUp);
                //xaml settings
                //MouseLeftButtonDown = "shape_MouseLeftButtonDown" 
                //MouseLeftButtonUp = "shape_MouseLeftButtonUp" 
                //MouseMove = "shape_MouseMove"
                addSemiOnlyCount++;
                img.Tag = "addSemiOnlyId_" + addSemiOnlyCount;
                img.Name = "addSemiOnlyId_" + addSemiOnlyCount;
                img.ToolTip = "Item ID: addSemiOnlyId_" + addSemiOnlyCount;
                img.Height = 90;
                
                LayoutRoot.Children.Add(img);
