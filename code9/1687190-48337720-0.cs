    using Android.App;
    using Android.Widget;
    using Android.OS;
    using Javax.Crypto.Spec;
    using Java.Lang;
    using Java.IO;
    using Javax.Crypto;
    using System.Text;
    
    namespace EncryTest
    {
        [Activity(Label = "EncryTest", MainLauncher = true)]
        public class MainActivity : Activity
        {
            long stopTime, startTime;
            private string sKey = "0123456789abcdef";//key，
            private string ivParameter = "1020304050607080";
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                encrypt("videoplayback.mp4");
                decrypt("videoplayback.mp4");
            }
    
            public void encrypt(string filename)
            {
    
                // Here you read the cleartext.
                try
                {
                    File extStore = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMovies);
                    startTime = System.DateTime.Now.Millisecond;
                    Android.Util.Log.Error("Encryption Started", extStore + "/" + filename);
    
                    // This stream write the encrypted text. This stream will be wrapped by
                    // another stream.
                    createFile(filename, extStore);
                    System.IO.FileStream fs=System.IO.File.OpenRead(extStore + "/" + filename);
                    FileOutputStream fos = new FileOutputStream(extStore + "/" + filename + ".aes", false);
                    
                    // Length is 16 byte
                    Cipher cipher = Cipher.GetInstance("AES/CBC/PKCS5Padding");
                    byte[] raw = System.Text.Encoding.Default.GetBytes(sKey);
                    SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
                    IvParameterSpec iv = new IvParameterSpec(System.Text.Encoding.Default.GetBytes(ivParameter));//
                    cipher.Init(CipherMode.EncryptMode, skeySpec, iv);
                    
                    // Wrap the output stream
                    CipherInputStream cis = new CipherInputStream(fs, cipher);
                    // Write bytes
                    int b;
                    byte[] d = new byte[1024 * 1024];
                    while ((b = cis.Read(d)) != -1)
                    {
                        fos.Write(d, 0, b);
                    }
                    // Flush and close streams.
                    fos.Flush();
                    fos.Close();
                    cis.Close();
                    stopTime = System.DateTime.Now.Millisecond;
                    Android.Util.Log.Error("Encryption Ended", extStore + "/5mbtest/" + filename + ".aes");
                    Android.Util.Log.Error("Time Elapsed", ((stopTime - startTime) / 1000.0) + "");
                }
                catch (Exception e)
                {
                    Android.Util.Log.Error("lv",e.Message);
                }
    
            }
    
    
            private void createFile(string filename, File extStore)
            {
                File file = new File(extStore + "/" + filename + ".aes");
    
                if (filename.IndexOf(".") != -1)
                {
                    try
                    {
                        file.CreateNewFile();
                    }
                    catch (IOException e)
                    {
                        // TODO Auto-generated catch block
                        Android.Util.Log.Error("lv",e.Message);
                    }
                    Android.Util.Log.Error("lv","file created");
                }
                else
                {
                    file.Mkdir();
                    Android.Util.Log.Error("lv","folder created");
                }
    
                file.Mkdirs();
            }
            public void decrypt(string filename)
            {
                try
                {
    
                    File extStore = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryMovies);
                    Android.Util.Log.Error("Decryption Started", extStore + "");
                    FileInputStream fis = new FileInputStream(extStore + "/" + filename + ".aes");
    
                    createFile(filename, extStore);
                    FileOutputStream fos = new FileOutputStream(extStore + "/" + "decrypted" + filename, false);
                    System.IO.FileStream fs = System.IO.File.OpenWrite(extStore + "/" + "decrypted" + filename);
                    // Create cipher
    
                    Cipher cipher = Cipher.GetInstance("AES/CBC/PKCS5Padding");
                    byte[] raw = System.Text.Encoding.Default.GetBytes(sKey);
                    SecretKeySpec skeySpec = new SecretKeySpec(raw, "AES");
                    IvParameterSpec iv = new IvParameterSpec(System.Text.Encoding.Default.GetBytes(ivParameter));//
                    cipher.Init(CipherMode.DecryptMode, skeySpec, iv);
    
                    startTime = System.DateTime.Now.Millisecond;
                    CipherOutputStream cos = new CipherOutputStream(fs, cipher);
                    int b;
                    byte[] d = new byte[1024 * 1024];
                    while ((b = fis.Read(d)) != -1)
                    {
                        cos.Write(d, 0, b);
                    }
    
                    stopTime = System.DateTime.Now.Millisecond;
    
                    Android.Util.Log.Error("Decryption Ended", extStore + "/" + "decrypted" + filename);
                    Android.Util.Log.Error("Time Elapsed", ((stopTime - startTime) / 1000.0) + "");
    
                    cos.Flush();
                    cos.Close();
                    fis.Close();
                }
                catch (Exception e)
                {
                    Android.Util.Log.Error("lv", e.Message);
                }
            }
        }
    }
