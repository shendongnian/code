    DrawingGroup backingStore = new DrawingGroup();
    
    protected override void OnRender(DrawingContext drawingContext) {      
        base.OnRender(drawingContext);            
    
        Render(); // put content into our backingStore
        drawingContext.DrawDrawing(backingStore);
    }
    
    // I can call this anytime, and it'll update my visual drawing
    // without ever triggering layout or OnRender()
    public void Render() {            
        var drawingContext = backingStore.Open();
        Render(drawingContext);
        drawingContext.Close();            
    }
    private void Render(DrawingContext drawingContext) {
        // move the code from your OnRender() here
    } 
