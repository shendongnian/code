    private void SetHighLight()
    {
      InkDrawingAttributes drawingAttributes = 
    inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();
      InkDrawingAttributes attributes = new InkDrawingAttributes();
      attributes.PenTip = PenTipShape.Rectangle;
      attributes.Size = new Size(4, 10);
      attributes.Color = drawingAttributes.Color;
      inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(attributes);
    }
