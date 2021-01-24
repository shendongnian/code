    public BitmapSource Imagem
    {
        get
        {
            if (_imagem == null)
                _imagem = LoadImage();
            return _imagem;
        }
    }
    BitmapSource _imagem;
