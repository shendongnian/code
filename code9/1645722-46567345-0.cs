    public ImageSource Icon
    {
        get
        {
            if (isFolder)
            {
                return new BitmapImage(new Uri(
                    "pack://application:,,,/ComputerProject;component/Resources/FolderIcon.jpg"));
            }
            return null; //TODO
        }
    }
