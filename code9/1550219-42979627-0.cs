     void sendInfo()
    {
        for (int i = 0; i < peltiers.Length; i++)
        {
            peltierInfo += ",";
            peltierInfo += peltiers[i].GetComponent<Peltier>().hot.ToString();
            peltierInfo += ",";
            peltierInfo += peltiers[i].GetComponent<Peltier>().temp.ToString("D3");
        }
        //Debug.Log(peltierInfo);
        sp.WriteLine(peltierInfo);
        sp.BaseStream.Flush();
        peltierInfo = "";
    }
