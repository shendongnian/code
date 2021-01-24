    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "CubeObstacle")
        {
            foreach (ContactPoint2D contact in col.contacts)
            {
    
                GameObject obj = Instantiate(particleSystemPrefab, contact.point, Quaternion.identity);
                ParticleSystem m_System = obj.GetComponent<ParticleSystem>();
                ParticleSystem.MainModule main = m_System.main;
                //Use Unscaled Time
                main.useUnscaledTime = true;
    
            }
            Time.timeScale = 0;
            ui.gameOverActivated();
            am.playerSound.Stop();
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
        }
    }
