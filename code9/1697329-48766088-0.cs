        public struct stReferenceMatch
    {
        public bool bAllocated;
        public bool bDeAllocated;
    }
    class ReadFromFile1
    {
        static string strFileName = @"C:\LogFile.Log";
        static void Main()
        {
            List<string>  linesList = File.ReadAllLines(strFileName).ToList();
            Dictionary<int, stReferenceMatch> IndexesTobeRemoved = new Dictionary<int, stReferenceMatch>();
            foreach (string line in linesList)
            {
                bool bAlloc, bDeAlloc;
                FindAllocDeAllocInString(line, out bAlloc, out bDeAlloc);
                if (bAlloc || bDeAlloc)
                {
                    int iIndex = line.IndexOf("Item :");
                    string strPointerId = line.Substring(iIndex + 6, line.Length - 1 - (iIndex + 5));
                    int iPos = Convert.ToInt32(strPointerId);
                    IndexesTobeRemoved.TryGetValue(iPos, out stReferenceMatch refMatch);
                    if (bAlloc) refMatch.bAllocated = true;
                    if (bDeAlloc) refMatch.bDeAllocated = true;
                }
            }
            using (var writer = new StreamWriter(@"C:\output_new.txt"))
            {
                foreach (var line in linesList)
                {
                    bool bAlloc, bDeAlloc;
                    FindAllocDeAllocInString(line, out bAlloc, out bDeAlloc);
                    if (bAlloc || bDeAlloc)
                    {
                        int iIndex = line.IndexOf("Item :");
                        string strPointerId = line.Substring(iIndex + 6, line.Length - 1 - (iIndex + 5));
                        int iPos = Convert.ToInt32(strPointerId);
                        IndexesTobeRemoved.TryGetValue(iPos, out stReferenceMatch refMatch);
                        if (refMatch.bAllocated && refMatch.bDeAllocated)
                            continue;
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
        private static bool FindAllocDeAllocInString(string line, out bool bAlloc, out bool bDeAlloc)
        {
            // Search For Allocation & DeAllocation
            bAlloc = line.Contains("Allocation");
            bDeAlloc = line.Contains("Deallocation");
            return bAlloc || bDeAlloc;
        }
    }
