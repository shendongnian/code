    public interface IActive {
        bool IsActive { get; }
    }
    public interface IFixedAt : IActive {
        void FixedAt(); 
    }
    
    public interface IUpdateAt : IActive {
        void UpdateAt();
    }
    
    public interface ILateUpdateAt : IActive {
        void LateUpdateAt();
    }
