            foreach (Student o in oldList)
            {
                bool flag = false;
                foreach (Student n in newList)
                {
                    if (FindStudent(o.ID, n.ID))
                    {
                        if (CheckChanges(o, n))
                        {
                            changed.Add(n);
                            flag = true;
                            break;
                        }
                    }
                    else
                    {
                        removed.Add(o);
                        flag = true;
                        break;
                    }
                }
                if(flag) continue;
            }
