    private void OnMouseMove(object sender, MouseEventArgs mouseEventArgs)
            {
                Console.WriteLine("(Window) MouseMove");
    
                UIElement element = GetAtMousePos();
                if (element != null)
                {
                    if (element.GetType() == typeof(Rectangle))
                    {
                        TestOnMouseEnter(element, mouseEventArgs);
                    }
                }
    
    
    
                var pos = mouseEventArgs.GetPosition(this);
                Line.X2 = pos.X;
                Line.Y2 = pos.Y;
            }
