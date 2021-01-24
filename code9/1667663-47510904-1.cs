    /// <summary>
    /// This class wraps the AES encryption algorithm (RijndaelManaged class) and can be used to encrypt and decrypt data.
    /// The passphrases hash value is used to set the key and initialization vector of the algorithm. Internally, SHA384
    /// is used to create a 192 bits key and a 128 bits initialization vector.
    /// </summary>
    public class SymmetricEncryptionHelper : IDisposable
    {
      private RijndaelManaged _algorithm = null;
      private byte[]          _iv = null; // initialization vector
      private byte[]          _key = null; // key
      private string          _passPhrase = string.Empty;
      private int             _streamBufferLength = 2048;
      private PaddingMode     _padding;
    
      /// <summary>
      /// Creates a SymmetricEncryptionHelper object.
      /// </summary>
      /// <param name="passPhrase">The passphrase.</param>
      public SymmetricEncryptionHelper(string passPhrase)
        : this(passPhrase, PaddingMode.PKCS7)
      {
      }
    
      /// <summary>
      /// Creates a SymmetricEncryptionHelper object.
      /// </summary>
      /// <param name="passPhrase">The passphrase.</param>
      /// <param name="padding">The padding mode to use.</param>
      public SymmetricEncryptionHelper(string passPhrase, PaddingMode padding)
      {
        this.PassPhrase = passPhrase;
        _padding        = padding;
      }
    
      /// <summary>
      /// Sets the required passphrase
      /// </summary>
      public string PassPhrase
      {
        set
        {
          if (value == null)
            throw new ArgumentNullException("PassPhrase");
          if (value.Length < 1)
            throw new ArgumentException("PassPhrase.Length < 1", "PassPhrase");
    
          _passPhrase = value;
          InitializeKeys();
          _algorithm = null; // reset algorithm, because the passphrase has changed
        }
      }
    
      /// <summary>
      /// Gets or sets the internal buffer length used for encryption/decryption if streams are used.
      /// Range [16...4096].
      /// </summary>
      public int StreamBufferLength
      {
        get { return _streamBufferLength; }
        set
        {
          if (value < 16)
            throw new ArgumentOutOfRangeException("StreamBufferLength", value, "StreamBufferLength < 16");
          if (value > 4096)
            throw new ArgumentOutOfRangeException("StreamBufferLength", value, "StreamBufferLength > 4096");
    
          _streamBufferLength = value;
        }
      }
    
      /// <summary>
      /// Creates
      /// </summary>
      /// <param name="data"></param>
      /// <returns></returns>
      private CryptData CreateSHA384Hash(CryptData data)
      {
        CryptData hash = new CryptData();
    
        using (var algorithm = new SHA384Managed())
        {
          hash.Buffer = algorithm.ComputeHash(data.Buffer);
        }
    
        return hash;
      }
    
      /// <summary>
      /// Initializes the key and initialization vector using the passphrases hash value.
      /// </summary>
      protected virtual void InitializeKeys()
      {
        // create a 48 byte hash value used to initialize the initialization vector and the key
        CryptData hashValue = CreateSHA384Hash(new CryptData(_passPhrase));
    
        // create the key and initialization vector
        this._key = new byte[24]; // 192 bits
        this._iv = new byte[16]; // 128 bits
    
        // copy the results
        Array.Copy(hashValue.Buffer, _key, _key.Length);
        Array.Copy(hashValue.Buffer, _key.Length, _iv, 0, _iv.Length);
      }
    
      /// <summary>
      /// Initializes the internal RijndaelManaged algorithm, assigns the key and
      /// initialization vector. If the object already exists, nothing is done.
      /// </summary>
      protected virtual void InitializeAlgorithm()
      {
        if (_algorithm == null)
        {
          _algorithm         = new RijndaelManaged();
          _algorithm.Key     = _key;
          _algorithm.IV      = _iv;
          _algorithm.Padding = _padding;
        }
      }
    
      /// <summary>
      /// Encrypts the given data.
      /// </summary>
      /// <param name="data">The data to encrypt.</param>
      /// <returns>Returns the encrypted data.</returns>
      public CryptData Encrypt(CryptData data)
      {
        if (data == null)
          throw new ArgumentNullException("data");
        if (data.Buffer == null)
          throw new ArgumentNullException("data.Buffer");
        if (data.BufferLength < 1)
          throw new ArgumentException("data.BufferLength < 1", "data.Buffer");
    
        ICryptoTransform transform = null;
        MemoryStream memStream = null;
        CryptoStream cryptoStream = null;
        CryptData resultData = null;
    
        try
        {
          InitializeAlgorithm();
          transform = _algorithm.CreateEncryptor();
          memStream = new MemoryStream();
          cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
          cryptoStream.Write(data.Buffer, 0, data.BufferLength);
          cryptoStream.FlushFinalBlock();
    
          resultData = new CryptData(memStream.ToArray());
          resultData.NumPaddingBytes = resultData.BufferLength - data.BufferLength;
        }
        catch (Exception ex)
        {
          Debug.WriteLine("SymmetricEncryptionHelper.Encrypt exception: " + ex);
          throw;
        }
        finally
        {
          if (transform != null)
            transform.Dispose();
          if (memStream != null)
            memStream.Close();
          if (cryptoStream != null)
            cryptoStream.Dispose();
        }
    
        return resultData;
      }
    
      /// <summary>
      /// Encrypts the given data.
      /// </summary>
      /// <param name="stream">The stream to encrypt.</param>
      /// <returns>Returns the encrypted data.</returns>
      public CryptData Encrypt(System.IO.Stream stream)
      {
        if (stream == null)
          throw new ArgumentNullException("stream");
        if (stream.Length < 1)
          throw new ArgumentException("stream.Length < 1", "stream");
    
        ICryptoTransform transform = null;
        MemoryStream memStream = null;
        CryptoStream cryptoStream = null;
        CryptData resultData = null;
        byte[] buffer;
        int writtenBytes;
    
        try
        {
          InitializeAlgorithm();
          transform = _algorithm.CreateEncryptor();
          memStream = new MemoryStream();
          cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Write);
    
          buffer = new byte[_streamBufferLength];
          stream.Position = 0;
          while (0 < (writtenBytes = stream.Read(buffer, 0, buffer.Length)))
          {
            cryptoStream.Write(buffer, 0, writtenBytes);
          }
          cryptoStream.FlushFinalBlock();
    
          resultData = new CryptData(memStream.ToArray());
          resultData.NumPaddingBytes = resultData.BufferLength - (int)stream.Length;
        }
        catch (Exception ex)
        {
          Debug.WriteLine("SymmetricEncryptionHelper.Encrypt exception: " + ex);
          throw;
        }
        finally
        {
          if (transform != null)
            transform.Dispose();
          if (memStream != null)
            memStream.Close();
          if (cryptoStream != null)
            cryptoStream.Dispose();
        }
    
        return resultData;
      }
    
      /// <summary>
      /// Decrypts the given data.
      /// </summary>
      /// <param name="encryptedData">The encrypted data.</param>
      /// <returns>Returns the decrypted data.</returns>
      public CryptData Decrypt(CryptData encryptedData)
      {
        if (encryptedData == null)
          throw new ArgumentNullException("encryptedData");
        if (encryptedData.Buffer == null)
          throw new ArgumentNullException("encryptedData.Buffer");
        if (encryptedData.BufferLength < 1)
          throw new ArgumentException("encryptedData.BufferLength < 1", "encryptedData.Buffer");
    
        ICryptoTransform transform = null;
        MemoryStream memStream = null;
        CryptoStream cryptoStream = null;
        CryptData resultData = null;
        byte[] decryptedBuffer;
    
        try
        {
          InitializeAlgorithm();
          transform = _algorithm.CreateDecryptor();
          memStream = new MemoryStream(encryptedData.Buffer);
          cryptoStream = new CryptoStream(memStream, transform, CryptoStreamMode.Read);
    
          // create result buffer and read the data from the crypto stream (do decryption)
          decryptedBuffer = new byte[encryptedData.BufferLength];
          cryptoStream.Read(decryptedBuffer, 0, decryptedBuffer.Length);
    
          // create the result data
          if (encryptedData.NumPaddingBytes > 0)
          { // remove padded bytes if neccessary
            byte[] decryptedBufferUnpadded = new byte[decryptedBuffer.Length - encryptedData.NumPaddingBytes];
            Array.Copy(decryptedBuffer, decryptedBufferUnpadded, decryptedBufferUnpadded.Length);
            resultData = new CryptData(decryptedBufferUnpadded);
          }
          else
            resultData = new CryptData(decryptedBuffer);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("SymmetricEncryptionHelper.Decrypt exception: " + ex);
          throw;
        }
        finally
        {
          if (transform != null)
            transform.Dispose();
          if (memStream != null)
            memStream.Close();
          if (cryptoStream != null)
            cryptoStream.Dispose();
        }
    
        return resultData;
      }
    
      /// <summary>
      /// Decrypts the given data.
      /// </summary>
      /// <param name="encryptedStream">The encrypted stream.</param>
      /// <returns>Returns the decrypted data.</returns>
      public CryptData Decrypt(System.IO.Stream encryptedStream)
      {
        if (encryptedStream == null)
          throw new ArgumentNullException("encryptedStream");
        if (encryptedStream.Length < 1)
          throw new ArgumentException("encryptedStream.Length < 1", "encryptedStream");
    
        ICryptoTransform transform = null;
        MemoryStream memStream = null;
        CryptoStream cryptoStream = null;
        CryptData resultData = null;
        byte[] decryptedBuffer;
        int readBytes;
    
        try
        {
          InitializeAlgorithm();
          transform = _algorithm.CreateDecryptor();
          memStream = new MemoryStream(_streamBufferLength);
          cryptoStream = new CryptoStream(encryptedStream, transform, CryptoStreamMode.Read);
    
          // create result buffer and read the data from the crypto stream (do decryption)
          decryptedBuffer = new byte[_streamBufferLength];
          while (0 < (readBytes = cryptoStream.Read(decryptedBuffer, 0, decryptedBuffer.Length)))
          {
            memStream.Write(decryptedBuffer, 0, readBytes); // store decrypted bytes
          }
    
          // create the result data
          resultData = new CryptData(memStream.ToArray());
        }
        catch (Exception ex)
        {
          Debug.WriteLine("SymmetricEncryptionHelper.Decrypt exception: " + ex);
          throw;
        }
        finally
        {
          if (transform != null)
            transform.Dispose();
          if (memStream != null)
            memStream.Close();
          if (cryptoStream != null)
            cryptoStream.Dispose();
        }
    
        return resultData;
      }
    
      /// <summary>
      /// Disposes the object.
      /// </summary>
      public void Dispose()
      {
        try
        {
          if (_algorithm != null)
            _algorithm.Clear();
        }
        catch (Exception ex)
        {
          Debug.WriteLine("SymmetricEncryptionHelper.Dispose exception: " + ex);
        }
      }
    }
