    // C#
    private UnityEngine.UI.Image image ;
    
    private void Awake()
    {
         image = GetComponent<UnityEngine.UI.Image>();
    
         HideImage();
    }
    
    public void HideImage()
    {
         image.enabled = false ;
    
         // ===== OR =====
    
         gameObject.SetActive(false);
    }
    
    public void ShowImage()
    {
         image.enabled = true;
    
         // ===== OR =====
    
         gameObject.SetActive(true);
    
    }
