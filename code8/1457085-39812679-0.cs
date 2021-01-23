    void Start()
    {
        StartCoroutine(readXML());
    }
    
    IEnumerator readXML()
    {
        Type[] itemTypes = { typeof(Equipment), typeof(Weapon), typeof(Consumeble), typeof(Jevelary) };
        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer), itemTypes);
    
        WWW www = new WWW(Application.streamingAssetsPath + "/" + "Items.xml");
        yield return www;
    
        if (string.IsNullOrEmpty(www.error))
        {
            string result = www.text;
            TextReader textReader = new StringReader(result);
    
            itemContainer = (ItemContainer)serializer.Deserialize(textReader);
            textReader.Close();
        }
    }
