    public TextMesh text;
    public int count;
    
    void Start()
    {
        count = 0;
        text = GameObject.Find("GameObjectTextMeshIsAttachedTo").GetComponent<TextMesh>();
        text.text = "Counter: " + count.ToString();
    }
