    public class BufferBase : MonoBehaviour
    {
    	/// <summary>
    	/// Indicates whether the buffer is activated
    	/// </summary>
    	protected bool _isBufferActive = false;
    	/// <summary>
    	/// Time until buffer ends
    	/// </summary>
    	protected float _bufferRemainingTime = 0f;
    
    
    	protected void FixedUpdateBuffer()
    	{
    		if (_isBufferActive)
    		{
    			_bufferRemainingTime -= Time.fixedDeltaTime;
    			if (_bufferRemainingTime <= 0)
    			{
    				EndBuffer();
    			}
    		}
    	}
    	
    	/// <summary>
    	/// Resets buffer
    	/// </summary>
    	protected void ResetBuffer()
    	{
    		_isBufferActive = false;
    		_bufferRemainingTime = 0;
    	}
    
    	/// <summary>
    	/// Marks the start of the buffer
    	/// </summary>
    	/// <param name="value"></param>
    	protected virtual void StartOrExtendBuffer(float value)
    	{
    		//set buffer values
    		_isBufferActive = true;
    		_bufferRemainingTime = value;
    
    		gameObject.SetActive(true);
    	}
    
    	/// <summary>
    	/// Marks the end of buffer
    	/// </summary>
    	protected virtual void EndBuffer()
    	{
    		_bufferRemainingTime = 0;
    		_isBufferActive = false;
    
    		gameObject.SetActive(false);
    	}
    }
