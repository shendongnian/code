    void OnTriggerEnter(Collider col) {
    if (col.tag == "Weapon") {
        attack(col);
        }
    }
    private void attack(Collider col) {
    
    if (!GameManager.instance.GameOver) {
    
    bulletReturnClone = Instantiate(bulletReturn,  transform.position, transform.rotation) as GameObject;
    bulletReturnClone.GetComponent<Rigidbody>().velocity = transform.forward * 25f;
    // the following line of code should remove the bullet from the shield collider in order to prevent any future problems like spawning multiple bullets or instantly destroying the newly created bullet
    bulletReturnClone.GetComponent<Transform>().position *= bulletReturnClone.GetComponent<Rigidbody>().velocity; 
    Destroy(col.gameObject);
        }
    }
