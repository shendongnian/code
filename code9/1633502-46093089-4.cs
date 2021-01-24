    private Vector2 GetDirectionToMouse()
    {
        var mousePosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 result = Input.mousePosition - mousePosition;
        return result;
    }
    float dragAngle;
    public void OnBeginDrag(PointerEventData data)
    {
        var directionToMouse = GetDirectionToMouse().normalized;
        var mouseAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        var transAngle = Mathf.Atan2(transform.up.z, transform.up.y) * Mathf.Rad2Deg;
        dragAngle = mouseAngle - transAngle;
    }    
    public void OnDrag(PointerEventData data)
    {
        var directionToMouse = GetDirectionToMouse().normalized;
        var mouseAngle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg;
        var targetAngle = mouseAngle - dragAngle;
        transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.right);
    }  
