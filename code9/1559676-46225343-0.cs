    new Actions(_driver).MoveToElement(element).Build().Perform();
    Thread.Sleep(1000);
    var sc = ((ITakesScreenshot) _driver).GetScreenshot();
    var remoteWebElement = element as RemoteWebElement;
    using (var img = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap)
    {
    if (remoteWebElement != null)
     img?.Clone(new Rectangle(remoteWebElement.LocationOnScreenOnceScrolledIntoView,remoteWebElement.Size), img.PixelFormat).Save(file, ImageFormat.Jpeg);
    }
