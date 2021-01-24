    public GameObject ContentPanel;
    public GameObject ListItemPrefab;
    
    // List of color option and corresponding names
    public List<Color> ColorOptions;
    public List<string> ColorNames;
    
    // Use this for initialization
    void Start () {
        for(int count=0;count<ColorOptions.Count;count++){
            //Spawn button
            GameObject newButton = Instantiate(ListItemPrefab) as GameObject;
            // Get button component
            ButtonController controller = newButton.GetComponent<ButtonController>();
            // Give button the color from the list 
            newButton.GetComponent<Image>().color = ColorOptions[count];
            // Give button the name from the list
            controller.Name.text = ColorNames[count];
            newButton.transform.SetParent(ContentPanel.transform);
            newButton.transform.localScale = Vector3.one;
        }
    }
