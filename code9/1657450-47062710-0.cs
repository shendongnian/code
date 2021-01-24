    Class WaveFile
     {
          byte[] byteArray;
          
          public void loadWaveFile(string filePath)
          {
               byteArray = File.ReadAllBytes(filePath);
          }
          public bool addEcho(int threadsNumber, int echoesNumber, int delay, int attenuation)
          {
               return true;
          }
          public bool saveWaveFile(string savingPath)
          {
               using (FileStream fs = new FileStream(@savingPath + "\\echo.wav", FileMode.Create))
               using (BinaryWriter writer = new BinaryWriter(fs))
               {
                    writer.Write(byteArray);                   
                    writer.Close();
                    fs.Close();
                    return true;
               }
          }
     }
