    void Main()
    {
    	using(var player = new BGM(@"D:\Test.mp3"))
    	{
    		player.Play();
    		
    		// TODO: Need to wait here in order for playback to complete
    		// Otherwise, you need to hold onto the player reference and dispose of it later
    		Console.ReadLine();
    	}
    }
    
    public class BGM : IDisposable
    {
    	private bool _isDisposed = false;
    	private ISoundOut _soundOut;
    	private IWaveSource _soundSource;
    	
    	public BGM(string file)
    	{
    		_soundSource = CodecFactory.Instance.GetCodec(file);
    		_soundOut = GetSoundOut();
    		_soundOut.Initialize(_soundSource);
    	}
    	
    	public void Play()
    	{
    		if(_soundOut != null)
    		{
    			_soundOut.Volume = 0.8f;
    			_soundOut.Play();
    		}
    	}
    	
    	public void Stop()
    	{
    		if(_soundOut != null)
    		{
    			_soundOut.Stop();
    		}
    	}
    	
    	private static ISoundOut GetSoundOut()
    	{
    		if (WasapiOut.IsSupportedOnCurrentPlatform)
    		{
    			return new WasapiOut
    			{
    				Device = GetDevice()
    			};
    		}
    		
    		return new DirectSoundOut();
    	}
    	
    	private static IWaveSource GetSoundSource(string file)
    	{
    		return CodecFactory.Instance.GetCodec(file);
    	}
    	
    	public static MMDevice GetDevice()
    	{
    		using(var mmdeviceEnumerator = new MMDeviceEnumerator())
    		{
    			using(var mmdeviceCollection = mmdeviceEnumerator.EnumAudioEndpoints(DataFlow.Render, DeviceState.Active))
    			{
                    // This uses the first device, but that isn't what you necessarily want
    				return mmdeviceCollection.First();
    			}
    		}
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (!_isDisposed)
    		{
    			if (disposing)
    			{
    				if(_soundOut != null)
    				{
    					_soundOut.Dispose();
    				}
    				
    				if(_soundSource != null)
    				{
    					_soundSource.Dispose();
    				}
    			}
    
    			_isDisposed = true;
    		}
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    	}
    }
