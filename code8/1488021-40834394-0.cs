    public bool HayConectividadsimple()
    {
        
        // For each node..
        for (int i = 0; i < Aristas.GetLength(0); i++)
        {
            // Assume it's not connected unless shown otherwise.
            bool nodeIsConnected=false;
            // Check the column and row at the same time:
            for (int j = 0; j < Aristas.GetLength(1); j++)
            {
                if (Aristas[i, j] != 0 || Aristas[j, i] != 0)
                {
                    // It was non-zero; must have at least one connection.
                    nodeIsConnected=true;
                    break;
                }
            }
            
            // Is the current node connected?
            if(!nodeIsConnected)
            {
                return false;
            }
         
        }
        
        // All ok otherwise:
        return true;
    }
