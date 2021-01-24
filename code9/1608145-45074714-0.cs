    string[] m_fileLine = File.ReadAllLines(@"F:\\assign.txt");
    StreamWriter m_results = new StreamWriter(@"F:\\results.txt", true);
    string tel_in = "TELENOR_BTS_INCOMING";
    for (int i = 0; i < m_fileLine.Length; i++)
    {
      if (m_fileLine[i].ToUpper().Contains(tel_in))
      {
      // some logic here...
      // then write here...
        m_results.WriteLine(m_fileLine[i].ToString());
        m_results.Flush();
      }
      else
      {
        // else logic and write here...
      }
                
    }
