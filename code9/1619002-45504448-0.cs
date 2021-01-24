    public class GetDefaultValues
    {
        public bool SetName(int i, string value)
        {
            switch (i)
            {
                case 0:
                    {
                        Name.Properties.Settings.Default.ChName1 = value;
                        break;
                    }
                case 1:
                    {
                        Name.Properties.Settings.Default.ChName2 = value;
                        break;
                    }
                default:
                    return false;
            }
    
            Name.Properties.Settings.Default.Save();
            return true;
        }
    
        public string GetName(int i)
        {
            switch (i)
            {
                case 0:
                    return Name.Properties.Settings.Default.ChName1;
                case 1:
                    return Name.Properties.Settings.Default.ChName2;
                default:
                    return "Not Implemented";
            }
        }
    }
