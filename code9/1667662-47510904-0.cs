    public class CryptData
    {
      private byte[]               _buffer;
      private System.Text.Encoding _textEncoding;
      private int                  _numPaddingBytes;
    
      public static readonly System.Text.Encoding DefaultTextEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
    
      public CryptData()
      {
        _textEncoding    = DefaultTextEncoding;
        _buffer          = null;
        _numPaddingBytes = 0;
      }
    
      public CryptData(byte[] buffer)
      {
        _textEncoding    = DefaultTextEncoding;
        _buffer          = buffer;
        _numPaddingBytes = 0;
      }
    
      public CryptData(System.Text.Encoding textEncoding)
      {
        if (textEncoding == null)
          throw new ArgumentNullException("textEncoding");
    
        _textEncoding    = textEncoding;
        _buffer          = null;
        _numPaddingBytes = 0;
      }
    
      public CryptData(System.Text.Encoding textEncoding, string text)
      {
        if (textEncoding == null)
          throw new ArgumentNullException("textEncoding");
    
        _textEncoding    = textEncoding;
        this.Text        = text;
        _numPaddingBytes = 0;
      }
    
      public CryptData(string text) : this(DefaultTextEncoding, text)
      {
      }
    
      public bool IsEmpty
      {
        get { return (_buffer == null || _buffer.Length < 1); }
      }
    
      public byte[] Buffer
      {
        get { return _buffer; }
        set { _buffer = value; }
      }
    
      public int BufferLength
      {
        get { return _buffer != null ? _buffer.Length : 0; }
      }
    
      public int NumPaddingBytes
      {
        get { return _numPaddingBytes; }
        set { _numPaddingBytes = value; }
      }
    
      public System.Text.Encoding TextEncoding
      {
        get { return _textEncoding; }
        set
        {
          if (value == null)
            throw new ArgumentNullException("TextEncoding");
    
          _textEncoding = value;
        }
      }
    
      public string Text
      {
        get
        {
          return (_buffer != null ? _textEncoding.GetString(_buffer) : null);
        }
        set
        {
          _buffer = ( value != null ? _textEncoding.GetBytes(value) : null);
        }
      }
    
      public string Base64Text
      {
        get
        {
          return (_buffer != null ? Convert.ToBase64String(_buffer) : null);
        }
        set 
        { 
          _buffer = (value != null ? Convert.FromBase64String(value) : null);
        }
      }
    }
