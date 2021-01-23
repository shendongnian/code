    private void common()
    {
       if (Headername[CI]== "Yellow")
        {
         switch (objnamewritten[CI])
          {
            case "Banana":
            case "Sun":
            case "lemomn":
                ppup.Height = Window.Current.Bounds.Height;
                ppup.IsOpen = true;
                break;
            default:
                ppup1.Height = Window.Current.Bounds.Height;
                ppup1.IsOpen = true;
                break;
           }
        }
    }
