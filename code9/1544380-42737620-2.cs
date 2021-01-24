    if (rigidbody.velocity.y > 0)
    {
        rigidbody.MoveRotation(Quaternion.Euler(new Vector3(0, 0, 0)));
    }
    else if (rigidbody.velocity.y < 0)
    {
        rigidbody.MoveRotation(Quaternion.Euler(new Vector3(0, 180, 0)));
    }
