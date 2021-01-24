    private void ExportPNG()
                {
                    var dir = Directory.GetCurrentDirectory();
                    var file = "ITEM_{0}.PNG";
                    var height = 100.0;
                    var width = 100.0;
        
                    var children = GetChildrenOfType<UCDisplayItem>(itC);
        
        
                    foreach (var item in children)
                    {
                        var path = System.IO.Path.Combine(dir, string.Format(file, DateTime.Now.Ticks));
        
                        Size size = new Size(width, height);
                        UIElement element = item as UIElement;
                        element.Measure(size);
                        element.Arrange(new Rect(new Point(0, 0), size));
        
                        RenderTargetBitmap renderTarget = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
                        VisualBrush sourceBrush = new VisualBrush(element);
        
                        DrawingVisual drawingVisual = new DrawingVisual();
                        DrawingContext drawingContext = drawingVisual.RenderOpen();
        
                        using (drawingContext)
                        {
                            drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0), new Point(width, height)));
                            //drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, (i - 1) * height), new Point(width, height + ((i - 1) * height))));
                        }
                        renderTarget.Render(drawingVisual);
        
                        PngBitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                        using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
                        {
                            encoder.Save(stream);
                        }
        
                    }
                }
    public List<T> GetChildrenOfType<T>( DependencyObject depObj)
       where T : DependencyObject
            {
                var result = new List<T>();
                if (depObj == null) return null;
                var queue = new Queue<DependencyObject>();
                queue.Enqueue(depObj);
                while (queue.Count > 0)
                {
                    var currentElement = queue.Dequeue();
                    var childrenCount = VisualTreeHelper.GetChildrenCount(currentElement);
                    for (var i = 0; i < childrenCount; i++)
                    {
                        var child = VisualTreeHelper.GetChild(currentElement, i);
                        if (child is T)
                            result.Add(child as T);
                        queue.Enqueue(child);
                    }
                }
    
                return result;
            }
