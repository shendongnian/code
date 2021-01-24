    public Panel panelToToggle;
    private void Awake()
    {
         // Gets the Panel component if there's one on the GameObject this
         // script is attached to
         panelToToggle = GetComponent<Panel>();
    }
    private void Start()
    {
         // Sets the parent gameObject of the Panel component to inactive
         panelToToggle.gameObject.SetActive(false)
    }
    private void EnablePanel()
    {
         // Sets the parent gameObject of the Panel component to active
         panelToToggle.gameObject.SetActive(true)
    }
