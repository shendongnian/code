        public bool IsBothEnabled
        {
            get
            {
                if (EnableBtn && EnableMail)
                    return true;
                return false;
            }
        }
