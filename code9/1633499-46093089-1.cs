    float lastAngle;
    bool isFirstClick = true;
    public void OnClick()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        
        if (isFirstClick)
        {
            baseAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
            baseAngle -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
            lastAngle = baseAngle;
            isFirstClick = false;
        }
        else
        {
            baseAnghle = lastAngle;
        }
        
    }
    public void OnDrag()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = Input.mousePosition - pos;
        lastAngle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.right);
    }
