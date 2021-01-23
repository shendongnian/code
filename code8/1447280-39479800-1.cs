    IEnumerable<Server> Zip(IEnumerable<IEnumerable<Server>> groups)
    {
        bool cont;
        int i = 0;
        do
        {
            cont = false;
            foreach (var grp in groups)
            {
                var element = grp.Skip(i).FirstOrDefault();
                if (element != null)
                {
                    cont = true;
                    yield return element;
                }
            }
            ++i;
        } while (cont);
    }
