    protected bool Collide()
    {
        PlayerRect = new Rectangle((int)playerPos.X, (int)playerPos.Y, playerFrameSize.X, playerFrameSize.Y);
        MobsRectGreen = new Rectangle((int)greenMobPos.X , (int)greenMobPos.Y , greenMobFrameSize.X , greenMobFrameSize.Y ;
        MobsRectOrange = new Rectangle((int)orangeMobPos.X,  (int)orangeMobPos.Y,  orangeMobFrameSize.X, orangeMobFrameSize.Y);
        return PlayerRect.Intersects(MobsRectGreen ) || return PlayerRect.Intersects(MobsRectOrange )  ;
    }
