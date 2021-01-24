    private async Task RotateElement(VisualElement element, CancellationToken cancellation)
    {
        while (!cancellation.IsCancellationRequested)
        {
            await element.RotateTo(360, 800, Easing.Linear);
            await element.RotateTo(0, 0); // reset to initial position
        }
    }
