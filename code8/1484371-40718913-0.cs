    void OnMouseDrag()
    {
        RotateChildren(transform);
        transform.Rotate(Input.GetAxis("Mouse Y") * multiplier, -Input.GetAxis("Mouse X") * multiplier, 0, Space.World);
    }
    private void RotateChildren(Transform transform)
    {
        foreach(Transform child in transform)
        {
            if(child.childCount > 0)
            {
                RotateChildren(child);
            }
            transform.Rotate(Input.GetAxis("Mouse Y") * multiplier, -Input.GetAxis("Mouse X") * multiplier, 0, Space.World);
        }
    }
