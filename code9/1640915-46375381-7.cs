That said, if you really want to continue with this, I strongly suggest you move the code in the Click handlers to a method. This reduces code duplication. i.e.
    private void DownButton_Click(...)
    {
        MovePlayer(0, 1);
    }
    private void UpButton_Click(...)
    {
        MovePlayer(0, -1);
    }
    public void MovePlayer(float xStep, float yStep)
    {
        x += xStep;
        y += yStep;
        MovePlayer();
        UpdateLabelLocation();
    }
To move down and left you'd call MovePlayer(-1, 1);
To move up and right you'd call MovePlayer(1, -1);
