    class ODataProxy<T>
    {
        public virtual IEnumerable<T> GetList(string query)
        {
        }
    }
    class ODataProxyStub : ODataProxy<EmployeeData>
    {
        public override IEnumerable<EmployeeData> GetList(string query)
        {
        }
    }
