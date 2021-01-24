    public ActionResult TestCrypto()
    {
        string encryptedText = Crypto.Encrypt("123456");
        string text = "Encrypted Text : " + encryptedText + "<br/>";
        string originalText = Crypto.Decrypt(encryptedText);
        text += "Origial Text : " + originalText;
        return Content(text);
    }
