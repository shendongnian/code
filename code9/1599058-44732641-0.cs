       class Flip_flop : Gate
        {
            bool state_, next_state_;
            public Flip_flop(string name) : base(name)
            {
                this.name_ = name;
            }
            public Flip_flop(string type, string name) : base(type, name)
            {
                this.name_ = name;
                state_ = false;
                next_state_ = false;
            }
    
    
            public override bool Validate_structural_semantics()
            {
                if (pins_.Count != 2) return false;
                pins_[0].Set_as_output();
                pins_[1].Set_as_input();
                return true;
            }
        }; // class flip_flop
