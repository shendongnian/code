    if (IntersectsFromTop(playerCollider, collider.BoundingBox))
    {
        _position.Y = collider.BoundingBox.Y - BoundingBox.Height;
    }
    else if (IntersectsFromRight(playerCollider, collider.BoundingBox))
    {
        _position.X = collider.BoundingBox.X + collider.BoundingBox.Width;
    }
    // And so on...
