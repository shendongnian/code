    protected override void OnClick(MouseEventArgs e)
    {
        Status tmp = m_status;
        if (m_status.HasFlag(Status.Checked))
            m_status &= ~Status.Checked;
        else
            m_status |= Status.Checked;
        if (tmp != m_status)
            Invalidate();
        base.OnClick(e);
    }
