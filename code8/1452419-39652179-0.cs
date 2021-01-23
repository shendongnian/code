    Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
                {
                    var workingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
                    var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
                    var corner = transform.Transform(new Point(workingArea.Right + 15, workingArea.Bottom - 10));
    
                    this.Left = corner.X - this.ActualWidth - 100;
                    this.Topmost = true;
                    this.Top = corner.Y - this.ActualHeight;
    
                }));
