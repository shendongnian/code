      private void txtsource_DragStarting(UIElement sender, DragStartingEventArgs args)
      {
          args.Data.SetText(txtsource.Text);
      }
      private async void txttarget_Drop(object sender, DragEventArgs e)
      {
          bool hasText = e.DataView.Contains(StandardDataFormats.Text);
          e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
          if (hasText)
          {
              var text = await e.DataView.GetTextAsync();
              txttarget.Text +="\n"+ text;
          }
      }
      private void txttarget_DragEnter(object sender, DragEventArgs e)
      {
          bool hasText = e.DataView.Contains(StandardDataFormats.Text);
          e.AcceptedOperation = hasText ? DataPackageOperation.Copy : DataPackageOperation.None;
          if (hasText)
          {
              e.DragUIOverride.Caption = "Drop here to insert text";
          }
      }
