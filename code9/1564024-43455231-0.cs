    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            hitEffect.transform.position = col.contacts[0].point;
            hitEffect.gameObject.SetActive(true);
    
            GameManager.Instance.playerController.anim.Squeeze();
    
            //------------------------------------------
            col.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            //------------------------------------------
        }
    }
