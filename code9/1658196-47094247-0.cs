    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "ThrowableBlue")
        {
            StartCoroutine(BowlDestroyTime(trig.gameObject));
            HP--;
            if (HP <= 0)
            {
                BlueWon.SetActive(true);
                Restart.SetActive(true);
                PlayerBlueController.canMove = false;
                PlayerBlueController.canFire = false;
            }
        }
    }
    
    IEnumerator BowlDestroyTime(GameObject tartgetObj)
    {
        yield return new WaitForSeconds(1);
        Destroy(tartgetObj);
    }
