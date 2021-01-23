    float _speed; //in m/s
    bool _spin; //in m/s^2
    
    void Update()
    {
      if (_spin)
        {
          transform.Rotate(_speed * Vector3.up * Time.deltaTime, Space.Self);
          _speed -= _deceleration * Time.deltaTime;
    
          //Stop when too slow.
          if (_speed < minSpeed)
            _spin = false;
        }
    }
    
    void OnClick()
    {
      if (!_spin)
        {
          _spin = true;
          _speed = Random.Range(speedFloor, speedCeiling);
          _deceleration = Random.Range(decFloor, decCeiling);
        }
    }
