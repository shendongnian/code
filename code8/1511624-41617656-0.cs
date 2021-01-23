    void plotSignal()
        {
            // http://writeablebitmapex.codeplex.com/
            WriteableBitmap writeableBmp = BitmapFactory.New(240, 1270);
            using (writeableBmp.GetBitmapContext())
            {
                //writeableBmp.SetPixel(10, 13, Colors.Black);
                writeableBmp.DrawLine(1, 2, 200, 400, Colors.Black);
                Image waveform = new Image();
                waveform.Source = writeableBmp;
                mainCanvas.Children.Add(waveform);
            }
        }
