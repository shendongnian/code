     void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            animator.SetBool("falling", false);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            animator.SetBool("falling", true);
        }
    }
