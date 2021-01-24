    private static void OnElapsed(Object sender, ElapsedEventArgs e)
    {
        Size size = pictureBox.Size;
        if (m_Reducing)
        {
            --size.Height;
            --size.Width;
            if ((size.Width == minimumWidth) && (size.Height == minimumHeight))
                m_Reducing = false;
        }
        else
        {
            ++size.Height;
            ++size.Width;
            if ((size.Width == maximumWidth) && (size.Height == maximumHeight))
                m_Reducing = true;
        }
        pictureBox.Size = size;
    }
