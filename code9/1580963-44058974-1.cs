    void writeInt(StreamWriter w, int i)
    {
        if (i<0)
        {
            w.Write('-');
            writeInt(w, -i);
        }
        else if (i>=10)
        {
            writeInt(w, i/10); // Write all but the last digit
            w.Write((char)('0' + i%10)); // Write the last digit
        }
        else
        {
            w.Write((char)('0' + i)); // Write single digit number
        }
    }
