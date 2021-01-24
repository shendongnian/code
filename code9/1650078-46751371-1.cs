    IEnumerable<string> Group(IEnumerable<int> sortedArr)
    {
        using (var en = sortedArr.GetEnumerator())
        {
            if (!en.MoveNext())
            {
                yield break;
            }
            int first = en.Current;
            int last = first;
            int count = 1;
            while (true)
            {
                bool end;
                if ((end = !en.MoveNext()) || last + 1 != en.Current)
                {
                    if (count == 1)
                    {
                        yield return first.ToString();
                    }
                    //else if (count == 2)
                    //{
                    //    yield return first.ToString();
                    //    yield return last.ToString();
                    //}
                    else
                    {
                        yield return first.ToString() + "-" + last.ToString();
                    }
                    if (end) { yield break; }
                    first = en.Current;
                    count = 1;
                }
                else
                {
                    ++count;
                }
                last = en.Current;
            }
        }
    }
