        static bool TestOrder(List<Team> list)
        {
            int tot = list.Count;
            for (int i = 0; i < tot; i++)
            {
                if (!list[i].Name.Equals((tot-i-1).ToString()))
                {
                    return false;
                }
            }
            return true;
        }
