    class UpdaterVisitor : IVisitor
    {
        readonly Player player;
        readonly Time time;
        public UpdaterVisitor(Player player, Time time)
        {
            this.player = player;
            this.time = time;
        }
        public void Visit(SceneObject o)
        {
            e.Update(time);
        }
        public void Visit(Enemy e)
        {
            e.Update(time, player);
        }
        public void Visit(Portal p)
        {
            p.Interact(ref player, player.Interact);
        }
    }
