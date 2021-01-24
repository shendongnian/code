    public List<Renderer> _Renderers; //here you must add the cubes manually in the inspector.
    Color _ColorToMatch; //this will automatically be set in the code.
    public bool CheckIfColorsMatch() {
        CheckIfValidVariables();
        for (int i = 0; i < _Renderers.Count; i++)
        {
            if (i == 0)
            {
                _ColorToMatch = _Renderers[i].material.color;
            }
            if (!_Renderers[i].material.color.Equals(_ColorToMatch))
            { 
                //If colors don't match, return false.
                return false;
            }
        } 
        //If all colors match, return true.
        return true;
    }
    void CheckIfValidVariables() {
        if (_Renderers == null)
        {
            //Renderer list no initiated.
            Debug.Log("Renderer list no initiated.");
            return;
        }
        if (_Renderers.Count == 0)
        {
            //No renderers set as reference.
            Debug.Log("No renderers set as reference.");
            return;
        }
    }
