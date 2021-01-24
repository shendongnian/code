    RaycastHit2D hit;
    public LayerMask mask;
    Vector2 mousePos;
    GameObject selectedObject;
    void Update() {
    
        // If mouse left click is pressed
        if (Input.GetMouseButtonDown(0)) {
            mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(mousePos, Vector2.zero, mask);
    
            if (hit.collider != null)
            {
                selectedObject = hit.collider.gameObject;
            }
        }
    }
Note that you have to set the public LayerMask in the inspector to only hit the Objects you want to hit.
With this script you should be able to send a Raycast from your screen towards your mouse and, if it hits any GameObject with the selected Layer in the LayerMask it will put that object in SelectedObject (and once you have the gameobject you can do whatever you want with it).
  [1]: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnMouseDown.html
