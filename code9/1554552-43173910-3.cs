     private void ScaleUpButton_Click(object sender, RoutedEventArgs e) {
          InkCanvasScaleTransform.ScaleX += .2;
          InkCanvasScaleTransform.ScaleY += .2;
    
        }
        private void ScaleDownButton_Click(object sender, RoutedEventArgs e) {
          InkCanvasScaleTransform.ScaleX -= .2;
          InkCanvasScaleTransform.ScaleY -= .2;
    
        }
    
        private void InkRedAttributesButton_Click(object sender, RoutedEventArgs e) {
          DrawingAttributes inkAttributes = new DrawingAttributes();
    
          inkAttributes.Height = 12;
          inkAttributes.Width = 12;
          inkAttributes.Color = Colors.Red;
          inkAttributes.IsHighlighter = true;
          myCanvas.DefaultDrawingAttributes = inkAttributes;
        }
    
        private void InkBlueAttributesButton_Click(object sender, RoutedEventArgs e) {
          DrawingAttributes inkAttributes = new DrawingAttributes();
    
          inkAttributes.Height = 12;
          inkAttributes.Width = 12;
          inkAttributes.Color = Colors.Blue;
          inkAttributes.IsHighlighter = true;
          myCanvas.DefaultDrawingAttributes = inkAttributes;
        }
