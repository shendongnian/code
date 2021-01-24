    public void handleInteraction(IBall ball1, IBall ball2)
    {
        var interaction = ball1.HandleInteraction(ball2);
        
        interaction.Handle();
    }
