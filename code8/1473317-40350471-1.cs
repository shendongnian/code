    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Media.Imaging;
    ...
    private async Task<BitmapImage> CreateBitmapImage(byte[] bytes)
    {
        var bitmapImage = new BitmapImage();
        using (var stream = new MemoryStream(bytes))
        {
            await bitmapImage.SetSourceAsync(stream.AsRandomAccessStream());
        }
        return bitmapImage;
    }
