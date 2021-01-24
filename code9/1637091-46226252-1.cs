    using System.Runtime.CompilerServices;
    ...
        public DateTime From {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get { return m_range.From; }
        }
