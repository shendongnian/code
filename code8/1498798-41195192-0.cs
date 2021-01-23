    int index;
    string  item;
    foreach (int i in lstPhotoType.SelectedIndices)
    {
        index = lstPhotoType.SelectedIndex;
        item = lstPhotoType.Items[i].ToString ();
        MessageBox.Show(item);
    }
