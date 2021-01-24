    void DrawMap(Graphics g)
    {
            if (Core.updatingBounds || MapProvider == EmptyProvider.Instance || MapProvider == null)
            {
                Debug.WriteLine("Core.updatingBounds");
                return;
            }
        
            ...
    }
