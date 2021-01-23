        public string getBase64Image(byte[] myImage)
        {
            if (myImage!= null)
            {
                return "data:image/jpeg;base64," + Convert.ToBase64String(myImage);
            }
            else
            {
                return string.Empty;
            }
        }
