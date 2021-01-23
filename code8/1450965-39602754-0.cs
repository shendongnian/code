    private readonly object padlock = new object();
    private int x;
    public void A()
    {
        lock (padlock)
        {
            // Will see changes made in A and B; may not see changes made in C
            x++;
        }
    }
    public void B()
    {
        lock (padlock)
        {
            // Will see changes made in A and B; may not see changes made in C
            x--;
        }
    }
    public void C()
    {
        // Might not see changes made in A, B, or C. Changes made here
        // might not be visible in other threads calling A, B or C.
        x = x + 10;
    }
