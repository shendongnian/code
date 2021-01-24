    using UnityEngine.UI
    
    public Button myButton; //Assign in inspector
    
    void Start()
    {
    myButton.onClick.AddListener(() => { Fire(); });
    }
