    [System.Serializable]
    public class BaseAbility
    {
        public int id;
        public string name;
    }
    [System.Serializable]
    public class GetBAResult
    {
        public List<BaseAbility> baseAbilities;
    }
    void Start()
    {
        // StartCoroutine(RespawnPlayer());
        string fixedJson = fixJson(w.text);
        //string fixedJson = fixJson("\"baseAbilities\":\"[{\"id\":1,\"name\":\"Focused Elemental Strike\"}]\"");
        Debug.Log("Fixed Json: " + fixedJson);
        GetBAResult P = JsonUtility.FromJson<GetBAResult>(fixedJson);
        Debug.Log("Count Json: " + P.baseAbilities.Count);
        for (int i = 0; i < P.baseAbilities.Count; i++)
        {
            Debug.Log("Name: " + P.baseAbilities[i].name);
            Debug.Log("Base ID: " + P.baseAbilities[i].id);
        }
    }
    string fixJson(string jsonToFix)
    {
        //First srting with `"` that will be removed
        const string firstString = "\"baseAbilities\":\"";
        //Last string with `"` that will be removed  
        const string lastString = "\"";
        //String that will be used to fix the "baseAbilities":"[ with the `"`
        const string fixedFirstString = "\"baseAbilities\":";
        //Get the first Index of firstString
        int firstIndex = jsonToFix.IndexOf(firstString);
        //Remove First Index of `firstString` 
        jsonToFix = jsonToFix.Remove(firstIndex, firstString.Length);
        int lastIndex = jsonToFix.LastIndexOf(lastString);
        //Remove everything from Last `lastString` to the end
        jsonToFix = jsonToFix.Remove(lastIndex);
        //Append the correct/fixed string without `"` to the beginning of the json data
        jsonToFix = fixedFirstString + jsonToFix;
        //Add `{` to the begging and `}` to the end of the json data
        jsonToFix = "{" + jsonToFix + "}";
        return jsonToFix;
    }
