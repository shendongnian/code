    public class template
        {
            private List<sectiontappal> _sectionappal;
            public List<sectiontappal> sectiontappals
            {
                get
                {
                    if (_sectionappal == null)
                        _sectionappal = new List<sectiontappal>();
                    return _sectionappal;
                }
                set
                {
                    _sectionappal = value;
                }
            }
        }
