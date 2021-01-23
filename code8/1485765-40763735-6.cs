    public void FixedUpdate(){
        // calculate acceleration here...
        acceleration = ... ;
        if ( isPKeyDown ) {
            _rigidbody.AddRelativeForce(0f, 0f, thrust, ForceMode.Acceleration);
        }
    }
