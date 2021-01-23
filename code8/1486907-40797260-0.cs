    enum CharacterState
    {
        Attacking,
        Defending,
        Idle,
        Dead
    }
    class CharacterImage 
    {
        private CharacterState state;
        public CharacterState State
        {
            get { return state; }
            set
            {
                if (state == value)
                    return;
                state = value;               
            }
        }
    }
