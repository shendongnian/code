    public class MainActivity : Activity, TextureView.ISurfaceTextureListener
    {
        private Android.Hardware.Camera _camera;
        private TextureView _textureView;
        private SurfaceView _surfaceView;
        private ISurfaceHolder holder;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            _textureView = (TextureView)FindViewById(Resource.Id.textureView);
            _textureView.SurfaceTextureListener = this;
    
            _surfaceView = (SurfaceView)FindViewById(Resource.Id.surfaceview);
            //set to top layer
            _surfaceView.SetZOrderOnTop(true);
            //set the background to transparent
            _surfaceView.Holder.SetFormat(Format.Transparent);
            holder = _surfaceView.Holder;
            _surfaceView.Touch += _surfaceView_Touch;
        }
    
        private void _surfaceView_Touch(object sender, View.TouchEventArgs e)
        {
            //define the paintbrush
            Paint mpaint = new Paint();
            mpaint.Color = Color.Red;
            mpaint.SetStyle(Paint.Style.Stroke);
            mpaint.StrokeWidth = 2f;
    
            //draw
            Canvas canvas = holder.LockCanvas();
            //clear the paint of last time
            canvas.DrawColor(Color.Transparent, PorterDuff.Mode.Clear);
            //draw a new one, set your ball's position to the rect here
            var x = e.Event.GetX();
            var y = e.Event.GetY();
            Rect r = new Rect((int)x, (int)y, (int)x + 100, (int)y + 100);
            canvas.DrawRect(r, mpaint);
            holder.UnlockCanvasAndPost(canvas);
        }
    
        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            _camera.StopPreview();
            _camera.Release();
    
            return true;
        }
    
        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            _camera = Android.Hardware.Camera.Open();
    
            try
            {
                _camera.SetPreviewTexture(surface);
                _camera.SetDisplayOrientation(90);
                _camera.StartPreview();
            }
            catch (Java.IO.IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    
        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
        }
    
        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
        }
    }
