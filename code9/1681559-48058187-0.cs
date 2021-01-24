    using (var ms = new MemoryStream((byte[])(bits))){
     ms.Position = 0; // Set stream position at the begin of the stream
     var image = System.Drawing.Image.FromStream(ms);
     pngTarget = Path.ChangeExtension(target, "png");
     image.Save(pngTarget, ImageFormat.Png);
     zip.AddEntry(pngTarget, ms.ToArray());
    }
