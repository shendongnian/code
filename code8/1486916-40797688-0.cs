    public enum CharacterState {
        Attacking,
        Defending,
        Idle,
        Dead
    }
    
    public class Character {
    
        public Character()
        {
            State = CharacterState.Idle;
        }
    
        private CharacterState state; //-Member variable (private)
    
        public CharacterState State 
        {  get
           {
                return state; // note the casing in State and state
           }  
           set
           {
               State = value;
           }
    }
