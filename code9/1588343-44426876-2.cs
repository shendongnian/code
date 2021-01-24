    DrawingGroup backingStore = new DrawingGroup();
    
    protected override void OnRender(DrawingContext drawingContext) {      
        base.OnRender(drawingContext);            
    
        Render(); // put content into our backingStore
        drawingContext.DrawDrawing(backingStore);
    }
    
    // Call render anytime, to update visual
    // without triggering layout or OnRender()
    public void Render() {            
        var drawingContext = backingStore.Open();
        Render(drawingContext);
        drawingContext.Close();            
    }
    private void Render(DrawingContext drawingContext) {
        // move the code from your OnRender() here
    } 
