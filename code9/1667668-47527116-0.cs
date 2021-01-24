    public class SeekbarStopTrackingTouchEventBinding: MvxAndroidTargetBinding
        {
            private readonly SeekBar _seekbar;
            private IMvxAsyncCommand<SeekBar.StopTrackingTouchEventArgs> _command;
            private string  testString;
    
            public SeekbarStopTrackingTouchEventBinding(SeekBar seekbar) : base(seekbar)
            {
                _seekbar = seekbar;
                _seekbar.StopTrackingTouch += ViewOnStopTrackingTouch;
            }
    
            private void ViewOnStopTrackingTouch(object sender, SeekBar.StopTrackingTouchEventArgs e)
            {
                if (_command != null)
                {
                    _command.Execute(e);
                }
            }
    
            public override Type TargetType
            {
                get { return typeof (IMvxAsyncCommand); } 
            }
    
            protected override void SetValueImpl(object target, object value)
            {
                try
                {
                    _command = (IMvxAsyncCommand<SeekBar.StopTrackingTouchEventArgs>)value;
                }
                catch (Exception e)
                {
                    Log.Error("SOME BINDER FAIL\n\t" + e.Message + "\n", "SOME BINDER FAIL\n\t" + e.Message + "\n");
                    throw;
                }
            }
    
    
            protected override void Dispose(bool isDisposing)
            {
                if (isDisposing)
                {
                    _seekbar.StopTrackingTouch -= ViewOnStopTrackingTouch;
                }
                base.Dispose(isDisposing);
            }
    
            public override MvxBindingMode DefaultMode
            {
                get { return MvxBindingMode.OneWay; }
            }
        }
