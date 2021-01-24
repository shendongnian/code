    void Lock(string A, string B, System.Action C, bool D, int E)
    {
        m_animator.GetComponent<Animator>().Play(A);
        d_animator.GetComponent<Animator>().Play(B);
        C();
        Dialyser.GetComponent<RotationByMouseDrag>().enabled = D;
        count = E;    
    }
    // ...
    Lock("Scale"', "CloseUp", ((MovieTexture)MovieOne.GetComponent<Renderer>().material.mainTexture).Play, false, 1 ) ;
