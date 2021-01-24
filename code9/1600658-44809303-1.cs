    private async void buttonSave_Click(object sender, RoutedEventArgs e)
    {
        XmlSerializer serializer = new XmlSerializer(personneList.GetType());
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        using (var stream = await folder.OpenStreamForWriteAsync("users.xml",
            CreationCollisionOption.ReplaceExisting))
        {
            serializer.Serialize(stream, personneList);
        }
    }
