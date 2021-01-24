    public Image Convert(byte[] source, Image destination, ResolutionContext context)
    {            
        using (var memStream = new System.IO.MemoryStream(source))
        using (var bitmap = Bitmap.FromStream(memStream))
        {                    
            var img = (Image)bitmap;
            return (Image)img.Clone();
        }
    }
