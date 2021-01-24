    void Update ()
    {
      if(Input.GetMouseButtonDown(0))
        {
            if (line == null) 
            {
                createLine ();
    
                mousePos = Camera.main.ScreenToWorldPoint (ProjectPointOnLine(Input.mousePosition, ruler.transform.forward, Input.mousePosition));
                mousePos.z = 0;
                line.SetPosition (0, mousePos);
    
                startPos = mousePos;
            }
        }
        else if(Input.GetMouseButtonUp(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(ProjectPointOnLine(Input.mousePosition, ruler.transform.forward, Input.mousePosition));
            mousePos.z = 0;
            line.SetPosition(1,mousePos);
            endPos = mousePos;
            addColliderToLine ();
            line = null;
            currLines++;
        }
        else if(Input.GetMouseButton(0) && line)
        {
            mousePos = Camera.main.ScreenToWorldPoint(ProjectPointOnLine(Input.mousePosition, ruler.transform.forward, Input.mousePosition));
            mousePos.z = 0;
            line.SetPosition(1, mousePos);
        }
    }
