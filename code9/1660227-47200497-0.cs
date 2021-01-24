    private void OnClick()
    {
        Vector2 origin = new Vector2(
                      Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                      Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        CmdOnClick(origin.x, origin.y);        
    }
    //this code will be executed on host only, but can be called from any client
    [Command(channel = 0)]
    private void CmdClickHandling(float x, float y)
    {
        RpcClick(x, y);
    }
    //this code will be executed on all clients
    [ClientRpc(channel = 0)]
    private void RpcClickHandling(float x, float y)
    {
        Vector2 osrigin = new Vector2(x, y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);
        if (hit && hit.transform.gameObject.tag.Equals("Untagged"))
        {
            
            hit.transform.gameObject.GetComponent<SpriteRenderer>().sprite = blueBarre.GetComponent<SpriteRenderer>().sprite;
            hit.transform.gameObject.tag = "ok";
        }
    }
    
