    public void EnvoiCommande(params byte[] donnees)
    {
       _outStream.Write(donnees, 0, 1);
       _outStream.Flush();
    }
    // Code Page
    EnvoiCommande(0x1b, 0x74; 0x13);
