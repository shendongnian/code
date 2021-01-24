    private void Awake()
    {
        OnKinematicValueChange += OnKinematicValueChange;
        // or
        OnKinematicValueChange += (sender, args) => 
        {
            // Event handling stuff
            // Disable isKinematic after 2 seconds with Coroutine etc.
        };
    {
    private void OnKinematicValueChange(object sender, EventArgs args);
    {
        // Event handling stuff
        // Disable isKinematic after 2 seconds with Coroutine etc.
    {
