       private IGroup m_group;
        public IGroup p_group
        {
            get
            {
                if (m_group == null)
                {
                    m_group = new Group();
                }
                return m_group;
            }
            set
            {
                m_group = value;
            }
        }
