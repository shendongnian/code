    int? _generatedRandom;
    public int GeneratedRandom
    {
        get { 
            if ( !_generatedRandom.HasValue )
                GenerateRandom();
    
            return _generatedRandom.Value;
        }
    }
    
    void GenerateRandom()
    {
        _generatedRandom = Random.Next(10, 100);
    }
