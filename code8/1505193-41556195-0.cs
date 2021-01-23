            async void SaveAsBitmap(object sender, RoutedEventArgs e)
        {
            //copy from origianl canvas and paste on the new canvas for saving
            var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
            //check if canvas is not empty
            if (strokes.Count == 0) return;
            //select all the strokes to be copied to the clipboard
            foreach (var stroke in strokes)
            {
                stroke.Selected = true;
            }
            inkCanvas.InkPresenter.StrokeContainer.CopySelectedToClipboard();
            //paste the strokes to a new InkCanvas and move the strokes to the topper left corner 
            var newCanvas = new InkCanvas();
            newCanvas.InkPresenter.StrokeContainer.PasteFromClipboard(new Point(0, 0));
            //using Win2D to save ink as png
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            CanvasRenderTarget renderTarget = new CanvasRenderTarget(device,
                (int)inkCanvas.InkPresenter.StrokeContainer.BoundingRect.Width,
                (int)inkCanvas.InkPresenter.StrokeContainer.BoundingRect.Height,
                96);
            
            using (var ds = renderTarget.CreateDrawingSession())
            {
                //ds.Clear(Colors.White); //uncomment this line for a white background
                ds.DrawInk(newCanvas.InkPresenter.StrokeContainer.GetStrokes());
            }
            //save file dialog
            var savePicker = new Windows.Storage.Pickers.FileSavePicker()
            {
                SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
            };
            savePicker.FileTypeChoices.Add("Image file", new List<string>() { ".jpeg", ".png" });
            savePicker.SuggestedFileName = "mysign.png";
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                {
                    await renderTarget.SaveAsync(fileStream, CanvasBitmapFileFormat.Png);
                }
            }
        }
