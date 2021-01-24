    private void OnMouseUp(...)
    {
        Invoke(new Action(() =>
        {
            // fill your list here
        }));
    }
    private void RegisterListener()
    {
        _app.Application.MouseUp += OnMouseUp;
    }
