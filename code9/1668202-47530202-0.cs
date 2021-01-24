      public List<object> CheckAccessCodes(object entity)
        {
            switch (entity)
            {
                case FirstEntity fe:
                    return fe.View.ToList();
                case SecondEntity se:
                    return se.View.ToList();
                default:
                    return null;
            }
        }
