    public enum ButtonType : byte {
        YES = 0,
        NO = (1 << 0)
    }
    // inside your button code
    [SerializeField]
    ButtonType _myType;
    public ButtonType Type { get { return _myType; } }
