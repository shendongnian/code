    void RemoveIfdefineDebug(string[] linesCode)
    {
        bool startRemove = false;
        for(int i=0;i<linesCode.Length;i++)
        {
            if(startRemove)
            {
                if (linesCode[i].Contains("#endif"))
                {
                    startRemove = false;
                }
                else
                    linesCode[i] = string.Empty;
            }
            if (linesCode[i].Contains("#ifdef "))
            {
                startRemove = true;
            }
        }
    }
