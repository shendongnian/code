    private void CreateandSave_Clicked(object sender, EventArgs e)
    {
        var s = DependencyService.Get<IFileHelper>().MakeFileStream();//using dependencyService to get a stream (there is no system.io.stream in PCL)
        // You want to remove that here as you created a public property of type XMLData.MyRootElement (called mre) holding user data instead 
        //XMLData xmldat = new XMLData();
        // Here you should await your `s` Task:
        await s;
        using (StreamWriter sw = new StreamWriter(s, Encoding.UTF8))
        {
            // Change of serialized type here
            XmlSerializer serializer = new XmlSerializer(typeof(XMLData.MyRootElement));
            // Here, just seralize the property saved through constructor
            serializer.Serialize(sw, mre);
        }
    }
