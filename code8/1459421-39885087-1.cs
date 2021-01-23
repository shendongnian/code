    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit dokunma;
            if (Physics.Raycast(rayCast, out dokunma, 10))
            {
                if (dokunma.collider.CompareTag("Oyuncu"))
                {
    
                    anim.SetBool("Bekle", false);
                    anim.SetBool("Saldir", true);
                }
                else
                {
                    anim.SetBool("Bekle", true);
                    anim.SetBool("Saldir", false);
                }
            }
        }
    }
