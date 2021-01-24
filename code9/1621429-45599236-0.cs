    public void Follow(IHaveForce target)
    {
        if (isFollowing)
        {
            Body.AddForce(FollowForce(target));
        }
        if (isAvoiding)
        {
            Body.AddForce(AvoidForce(target));
        }
    }
