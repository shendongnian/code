    private readonly MyAppContent conn = new MyAppContent();
    // other controller code
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            conn.Dispose();
        }
        base.Dispose(disposing);
    }
