    private static MuteScript singleton {get; private set;}
    private void Awake() {
        if (singleton == null) singleton = this;
        [whatever other stuff you were already doing in Awake()]
    }
    public static void ToggleMute(Graphic graphic)
    {
        singleton._ToggleMute(graphic);
    }
    private void _ToggleMute(Graphic graphic)
    {
        [whatever code you were running in your original mute method]
    }
