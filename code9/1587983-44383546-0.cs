    _ImageViewer.SetRenderWindow(renderWindow);
    _ImageViewer.GetRenderer().AddActor2D(sliceStatusActor);
    _ImageViewer.GetRenderer().AddActor2D(usageTextActor);
    _ImageViewer.SetSlice(_MinSlice);
    _ImageViewer.Render();
