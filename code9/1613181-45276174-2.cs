    using UnityEngine;
    
    namespace UnitySampleAssets._2D
    {
    
        [RequireComponent(typeof (PlatformerCharacter2D))]
        public class Platf : MonoBehavior    {
            private PlatformerCharacter2D character;
            private bool jump;
    
            public object CrossPlatformInputManager { get; private set; }
    
            public PlatformerCharacter2D Character
            {
                get
                {
                    return Character2;
                }
    
                set
                {
                    Character2 = value;
                }
            }
    
            public bool Jump
            {
                get
                {
                    return Jump2;
                }
    
                set
                {
                    Jump2 = value;
                }
            }
    
            public PlatformerCharacter2D Character1
            {
                get
                {
                    return Character2;
                }
    
                set
                {
                    Character2 = value;
                }
            }
    
            public bool Jump1
            {
                get
                {
                    return Jump2;
                }
    
                set
                {
                    Jump2 = value;
                }
            }
    
            public PlatformerCharacter2D Character2
            {
                get
                {
                    return Character3;
                }
    
                set
                {
                    Character3 = value;
                }
            }
    
            public bool Jump2
            {
                get
                {
                    return Jump3;
                }
    
                set
                {
                    Jump3 = value;
                }
            }
    
            public PlatformerCharacter2D Character3
            {
                get
                {
                    return character;
                }
    
                set
                {
                    character = value;
                }
            }
    
            public bool Jump3
            {
                get
                {
                    return jump;
                }
    
                set
                {
                    jump = value;
                }
            }
    
            private void Awake()
            {
                Character = GetComponent<PlatformerCharacter2D>();
            }
    
            private void Update()
            {
                if (!Jump)
                    // Read the jump input in Update so button presses aren't missed.
                Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
    
            private void FixedUpdate()
            {
                // Read the inputs.
                bool crouch = Input.GetKey(KeyCode.LeftControl);
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                // Pass all parameters to the character control script.
                Character.Move(h, crouch, Jump);
                Jump = false;
            }
        }
    }
