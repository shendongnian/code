    public void MoveUp(Object sender, MoveEventArgs e)
        {
            if (CanMoveUp(e.CurrentPosition.Y)) ...
        }
        public void MoveDown(Object sender, MoveEventArgs e)
        {
            if (CanMoveDown(e.CurrentPosition.Y)) ...
        }
        public void MoveLeft(Object sender, MoveEventArgs e)
        {
            if (CanMoveLeft(e.CurrentPosition.X)) ...
        }
        public void MoveRight(Object sender, MoveEventArgs e)
        {
            if (CanMoveRight(e.CurrentPosition.X)) ...
        }
        private bool CanMoveUp(double y) => (y - 1) > 0;
        private bool CanMoveDown(double y) => (y + 1) < 4;
        private bool CanMoveLeft(double x) => (x - 1) > 0;
        private bool CanMoveRight(double x) => (x + 1) < 4;
