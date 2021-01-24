    void writeInt(StreamWriter w, int i)
    {
        if (i<0)
        {
            w.Write('-');
            writeInt(-i);
        }
        else if (i>=10)
        {
            writeInt(i/10); // Write all but the last digit
            w.Write('0' + i%10); // Write the last digit
        }
        else
        {
            w.Write('0' + i); // Write single digit number
        }
    }
