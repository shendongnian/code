    public GameObject menu; // Your GUI
    private bool isShowing = false;
 
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isShowing = !isShowing; // Toggles the GUI
            menu.SetActive(isShowing);
        }
    }
