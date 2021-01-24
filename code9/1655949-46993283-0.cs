    private bool _foundEnemy;
    private Enemy _currentEnemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_foundEnemy) return;
        _currentEnemy = collision.GetComponent<Enemy>();
        // your code here
        _foundEnemy = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(_currentEnemy!=null && collision.GetComponent<Enemy>() == _currentEnemy)
            _foundEnemy = false;
    }
