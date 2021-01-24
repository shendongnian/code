    byte[] nameAsBytes = new byte[BYTES_PER_DEVICE_NAME];
    Marshal.Copy(nameAddress, nameAsBytes, 0, BYTES_PER_DEVICE_NAME);
    int strlen;
    for (strlen = 0; strlen < nameAsBytes.Length;strlen++)
    {
      if (nameAsBytes[strlen] == 0)
        break;
    }
    string nameAsString = System.Text.Encoding.UTF8.GetString(nameAsBytes, 0, strlen);
