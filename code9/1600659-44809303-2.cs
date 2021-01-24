    private async void buttonLoad_Click(object sender, RoutedEventArgs e)
    {
        XmlSerializer serializer = new XmlSerializer(personneList.GetType());
        StorageFolder folder = ApplicationData.Current.LocalFolder;
        using (var stream = await folder.OpenStreamForReadAsync("users.xml"))
        {
            personneList = (List<Model.Personne>)serializer.Deserialize(stream);
        }
    }
