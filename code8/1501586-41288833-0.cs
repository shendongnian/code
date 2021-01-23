    public bool  AddFragment (int _idNr, String _fileName, string _tile, int _duration)
    {
        // Scan the list, looking for an existing fragment with this id number.
        foreach (SoundFragment fs3 in Fragments)
        {
            if (fs3.IdNr == _idNr)
            {
                // found a matching fragment, so don't need to add.
                return false;
            }
        }
        // No matching fragment found. Add a new one.
        Fragments.Add(new SoundFragment(....));
        return true;
    }
