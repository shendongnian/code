    private void SetupVisualization(Windows.Foundation.Size framePizelSize, IList<DetectedFace> foundFaces)
        {
                this.VisualizationCanvas.Children.Clear();
    
                double actualWidth = this.VisualizationCanvas.ActualWidth;
                double actualHeight = this.VisualizationCanvas.ActualHeight;
    
                if (this.currentState == ScenarioState.Streaming && foundFaces != null && actualWidth != 0 && actualHeight != 0)
                {
                    double widthScale = framePizelSize.Width / actualWidth;
                    double heightScale = framePizelSize.Height / actualHeight;
    
                    foreach (DetectedFace face in foundFaces)
                    {
                        // Create a rectangle element for displaying the face box but since we're using a Canvas
                        // we must scale the rectangles according to the frames's actual size.
                        Rectangle box = new Rectangle();
                        box.Width = (uint)(face.FaceBox.Width / widthScale);
                        box.Height = (uint)(face.FaceBox.Height / heightScale);
                        box.Fill = this.fillBrush;
                        box.Stroke = this.lineBrush;
                        box.StrokeThickness = this.lineThickness;
                        box.Margin = new Thickness((uint)(face.FaceBox.X / widthScale), (uint)(face.FaceBox.Y / heightScale), 0, 0);
    
                        this.VisualizationCanvas.Children.Add(box);
                    }
                }
            }
