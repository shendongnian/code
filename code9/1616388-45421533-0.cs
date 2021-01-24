    public class DetailView
    {
      public DetailView()
      {
        // Synchronously load palceholder image.
        Image = <placeholder>;
        // Asynchronously load real image.
        LoadImageAsync();
      }
      private async Task LoadImageAsync()
      {
        try
        {
          Image = await Task.Run(() => GetAnImage());
        }
        catch (Exception ex)
        {
          // TODO: Determine what to do if the image loading fails.
        }
      }
      public Bitmap Image { get; private set; }
      Dispose() { Image?.Dispose(); }
    }
