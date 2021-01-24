    void Update()
    {
        if (triggerIsOn && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E button pressed");
            drinkAmin.Play("Dab");
            alcBottle.SetActive(true);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "vThirdPersonController")
        {
            Debug.Log("Detected vThirdPersonController");
            triggerIsOn = true;
            drinkText.SetActive(true);
        }
    }
    
    void OnTriggerExit(Collider other)
    {
    
        if (other.gameObject.name == "vThirdPersonController")
        {
            Debug.Log("Lost vThirdPersonController");
            triggerIsOn = false;
    
            drinkText.SetActive(false);
            alcBottle.SetActive(false);
        }
    }
