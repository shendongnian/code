    List<string> queue = new List<string>();
    
    public void PluginCallback(string name)
    {
        // instead of instantiating/modifying UI elements here, queue them for later
        queue.Add(name);
    }
    void Update()
    {
        // shouldn't be in a Graphic.Rebuild loop now
        if (queue.Count > 0)
        {
            foreach (string name in queue)
            {
                Text text = (Instantiate(prefab) as GameObject).GetComponent<Text>();
                text.text = name;
            }
            queue.Clear();
        }
    }
