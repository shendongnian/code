    private void Awake()
    {
        OnKinematicValueChange += OnKinematicValueChangeHandler;
        // or
        OnKinematicValueChange += (sender, args) => 
        {
            // Event handling stuff
            // Disable isKinematic after 2 seconds with Coroutine etc.
        };
    {
    private void OnKinematicValueChangeHandler(object sender, EventArgs args);
    {
        // Event handling stuff
        // Disable isKinematic after 2 seconds with Coroutine etc.
    {
