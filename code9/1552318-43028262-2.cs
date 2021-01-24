    private static bool IntersectsFromTop(Rectange player, Rectangle target)
    {
        var intersection = Rectangle.Intersect(player, target);
        return player.Intersects(target) && intersection.Y == target.Y && intersection.Width >= intersection.Height;
    }
    private static bool IntersectsFromRight(Rectange player, Rectangle target)
    {
        var intersection = Rectangle.Intersect(player, target);
        return player.Intersects(target) && intersection.X + intersection.Width == target.X + target.Width && intersection.Width <= intersection.Height;
    }
    // And so on...
