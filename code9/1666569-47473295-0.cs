    private void Update()
    {
        //check range
        if (Vector3.Distance(targetPos, turretPos) < maxRange)
            AutoAttack(targetPos);
    }
    public override void AutoAttack(Vector3 targetPos)
    {
        Vector3 a = targetPos - _transform.position;
        Vector3 b = Vector3.forward;
        float angle = Vector3.Angle(a, b);
        Rotation(Vector3.Cross(a, b).y > 0 ? -angle : angle);
        //this condition is to to fire only when the turret is currently looking at target
        if (Mathf.Abs(Mathf.DeltaAngle(_transform.eulerAngles.y, (Vector3.Cross(a, b).y > 0 ? -angle : angle))) < minAngleToFire)
            Attacking();
    }
    //call to rotate the in y axis
    public void RotationY(float angle)
    {
        _transform.rotation = Quaternion.Lerp(_transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * rotationSpeed);
    }
