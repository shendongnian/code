    void OBJManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        if (sender is TextBlock)
        {
            TextBlock temp = sender as TextBlock;
    
            if (forceManipulationsToEnd)
            {
                e.Complete();
                return;
            }
    
            var EleTrs = _ElementTrsDir[temp];
    
            EleTrs._previousTransform.Matrix = EleTrs._transformGroup.Value;
            Windows.Foundation.Point center = EleTrs._previousTransform.TransformPoint(new Windows.Foundation.Point(e.Position.X, e.Position.Y));
    
            EleTrs._compositeTransform.CenterX = center.X;
            EleTrs._compositeTransform.CenterY = center.Y;
    
            EleTrs._compositeTransform.Rotation = (e.Delta.Rotation * 180) / Math.PI;
            EleTrs._compositeTransform.ScaleX = EleTrs._compositeTransform.ScaleY = e.Delta.Scale;
            EleTrs._compositeTransform.TranslateX = e.Delta.Translation.X;
            EleTrs._compositeTransform.TranslateY = e.Delta.Translation.Y;
    
            e.Handled = true;
        }
    }
