    private Android.Hardware.Camera _camera;
    private TextureView _textureView;
    
    public static ImageView _focusimg;
    
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Main);
    
        _textureView = (TextureView)this.FindViewById(Resource.Id.textureView);
        _textureView.SurfaceTextureListener = this;
        _textureView.Touch += _textureView_Touch;
    
        var tpBtn = (Button)this.FindViewById(Resource.Id.take_photo);
        tpBtn.Click += TpBtn_Click;
    
        _focusimg = (ImageView)this.FindViewById(Resource.Id.focuscircle);
    }
