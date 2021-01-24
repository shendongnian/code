    TextMesh totaldigit = new TextMesh ();     
    void OnMouseUp()
    {
        if( PlayerCode.Length >= 4 )
            return ;
        PlayerCode += gameObject.name;
        totalDigits += 1;
    }
