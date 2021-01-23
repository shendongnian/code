        namespace WPFBattle
    {
        public enum CharacterState{
            Attacking = 1,
            Defending = 2,
            Idle = 3,
            Dead
        }
    
        class CharacterImage: System.Windows.Controls.Image
        {
    
            public CharacterState _state;
    
            public ImageSource IdleImageSource { get; set; }
            public ImageSource AttackingImageSource { get; set; }
            public ImageSource TakeDamageImageSource { get; set; }
            public ImageSource DeadImageSource { get; set; }
    
            protected void UpdateImageSource()
            {
                switch (_state)
                {
                    case CharacterState.Attacking:
                        this.Source = AttackingImageSource;
                        break;
                    case CharacterState.TakeDamage:
                        this.Source = TakeDamageImageSource;
                        break;
                    case CharacterState.Dead:
                        this.Source = DeadImageSource;
                        break;
                    case CharacterState.Idle:
                    default:
                        this.Source = IdleImageSource;
                        break;
                }
            }
    
            protected override void OnRender(DrawingContext dc)
            {
                UpdateImageSource();
                base.OnRender(dc);
            }
    
            public CharacterState State
            {
                get { return _state; }
                set
                {
                    _state = value;
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        UpdateImageSource();
                    }));
                }
            }
        }
    }
