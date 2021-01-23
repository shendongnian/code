    public string FixText(string A)
        {
           
            string newText = "";
            for (int i = 0; i < A.Length; i++)
            {
                switch (A.Substring(i, 1))
                {
                    case "A":
                        newText += A.Substring(i, 1).Replace("A", "C");
                        break;
                    case "F":
                        newText += A.Substring(i, 1).Replace("F", "H");
                        break;
                    case "C":
                        newText += A.Substring(i, 1).Replace("C", "W");
                        break;
                    case "B":
                        newText += A.Substring(i, 1).Replace("B", "G");
                        break;
                    default:
                        break;
                }
            }
            return newText;
        }
