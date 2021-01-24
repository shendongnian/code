    public void OneBallFire<T>() where T : MotherBall
    {
        GameObject ball = ballPool.GetObjectFromPool<T>(ballType);
        //I can't cast AScript, BScript or Motherball.
        T ballScript = ball.transform.GetComponent<T>();
        ballScript.Setting();
    }
    // BoolPool Todo This
    public T GetObjectFromPool<T>()
    {
        if(T is AScript)
           //Clone && Return a AScript Obj
        // Todo all type ....
        return null;
    }
