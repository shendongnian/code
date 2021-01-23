    private void UpdateItem(UITabBarItem item, string icon)
    {
        if (item == null)
             return;
        try
        {
             string newIcon = icon.Replace(".png", " Filled.png");
             if (item == null) return;
             if (item.SelectedImage == null) return;
             if (item.SelectedImage.AccessibilityIdentifier == icon) return;
				
			 item.Image = UIImage.FromBundle(icon);
			 item.Image = item.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysOriginal);
		     item.SelectedImage = UIImage.FromBundle(newIcon);
			 item.SelectedImage = item.SelectedImage.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysOriginal);
             item.SelectedImage.AccessibilityIdentifier = icon;
         }
         catch (Exception ex)
         {
             Console.WriteLine("Unable to set selected icon: " + ex);
         }
    }
