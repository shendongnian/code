    private bool _moveUp;
    private bool _moveDown;
    private bool _moveLeft;
    private bool _moveRight;
    
    // You can add the Timer in the Winforms Designer instead if you like;
    // The Interval property can be configured there at the same time, along
    // with the Tick event handler, simplifying the non-Designer code here.
    private System.Windows.Forms.Timer _movementTimer = new Timer { Interval = 100 };
    
    public MainForm()
    {
        InitializeComponent();
    
        _movementTimer.Tick += movementTimer_Tick;
    }
    
    private void movementTimer_Tick(object sender, EventArgs e)
    {
        _DoMovement();
    }
    
    private void _DoMovement()
    {
        if (_moveLeft) Player.MoveLeft();
        if (_moveRight) Player.MoveRight();
        if (_moveUp) Player.MoveUp();
        if (_moveDown) Player.MoveDown();
    }
    
    // You could of course override the OnKeyDown() method instead,
    // assuming the handler is in the Form subclass generating the
    // the event.
    public void MainForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.IsRepeat)
        {
            // Ignore key repeats...let the timer handle that
            return;
        }
    
        switch (e.KeyCode)
        {
        case Keys.Up:
            _moveUp = true;
            break;
        case Keys.Down:
            _moveDown = true;
            break;
        case Keys.Left:
            _moveLeft = true;
            break;
        case Keys.Right:
            _moveRight = true;
            break;
        }
    
        _DoMovement();
        _movementTimer.Start();
    }
    
    public void MainForm_KeyUp(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
        case Keys.Up:
            _moveUp = false;
            break;
        case Keys.Down:
            _moveDown = false;
            break;
        case Keys.Left:
            _moveLeft = false;
            break;
        case Keys.Right:
            _moveRight = false;
            break;
        }
    
        if (!(_moveUp || _moveDown || _moveLeft || _moveRight))
        {
            _movementTimer.Stop();
        }
    }
