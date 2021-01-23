    private IEnumerator myCoroutine ;
    
    // [...]
    if (currentAmmo < 2 && isColorFading == false) {
        myCoroutine = ColourPulse (ammoCounter, initialColor, 2) ;
        StartCoroutine ( myCoroutine ) ;
        isColorFading = true;
    } else if (currentAmmo >= 2 && isColorFading == true) {
        StopCoroutine (myCoroutine); 
        ammoCounter.color = initialColor;
        isColorFading = false;
    }
