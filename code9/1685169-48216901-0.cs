        private void OnCollisionEnter (Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
    private void OnCollisionExit (Collision collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }
