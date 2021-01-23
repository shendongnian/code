    [WebMethod]
    public void SaveData(string id, string formula, object[] chemicals)
    {
      for (int i = 0; i < chemicals.Length; i++)
      {
        // i-th entry in the chemicals array.
        var entry = ((Dictionary<string, object>)chemicals[i]);
        Debug.WriteLine(entry["id"]);
      }
    }
