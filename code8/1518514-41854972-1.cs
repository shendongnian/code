    void OnTriggerEnter(Collider other)
    {
        //else ...
        if (other.transform.root.CompareTag("Player")
            && other.transform.parent.GetComponent<Player>() == player)
        {
            print("Collision detected with trigger object " + player.name);
            safe = true;
            m_Player.PlayerIsSafe.Send(safe);
        }
    }
