    bool isAttackingPlayer = false;
    IEnumerator HarmPlayer()
    {
        Debug.Log("Inside Harm Player");
        yield return new WaitForSeconds(5);
        Debug.Log("Player Health is the issue");
        isAttackingPlayer = false; //Done attacking. Set to false
    }
    
    void Update()
    {
    
        transform.LookAt(target);
        float step = speed * Time.deltaTime;
        distance = (transform.position - target.position).magnitude;
        if (distance < 3.5)
        {
            if (isAttackingPlayer == false)
            {
                isAttackingPlayer = true; //Is attacking to true
                animator.SetFloat("Attack", 0.2f);
                StartCoroutine("HarmPlayer");
            }
        }
    }
