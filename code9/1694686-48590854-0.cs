        public interface ICommon
        {
            string CommonProperty1 { get; set; }
            int CommonProperty2 { get; set; }
            string CommonProperty3 { get; set; }
            string CommonProperty4 { get; set; }
            string CommonProperty5 { get; set; }
        }
        public class A2 : ICommon
        {
            private readonly A _data;
            public A2(A data)
            {
                _data = data;
            }
            public string CommonProperty1
            {
                get { return _data.CommonProperty1; }
                set { _data.CommonProperty1 = value; }
            }
            public int CommonProperty2
            {
                get { return _data.CommonProperty2; }
                set { _data.CommonProperty2 = value; }
            }
            public string CommonProperty3
            {
                get { return _data.CommonProperty3; }
                set { _data.CommonProperty3 = value; }
            }
            public string CommonProperty4
            {
                get { return _data.CommonProperty4; }
                set { _data.CommonProperty4 = value; }
            }
            public string CommonProperty5
            {
                get { return _data.CommonProperty5; }
                set { _data.CommonProperty5 = value; }
            }
        }
        public class B2 : ICommon
        {
            private readonly B _data;
            public B2(B data)
            {
                _data = data;
            }
            public string CommonProperty1
            {
                get { return _data.CommonProperty1; }
                set { _data.CommonProperty1 = value; }
            }
            public int CommonProperty2
            {
                get { return _data.CommonProperty2; }
                set { _data.CommonProperty2 = value; }
            }
            public string CommonProperty3
            {
                get { return _data.CommonProperty3; }
                set { _data.CommonProperty3 = value; }
            }
            public string CommonProperty4
            {
                get { return _data.CommonProperty4; }
                set { _data.CommonProperty4 = value; }
            }
            public string CommonProperty5
            {
                get { return _data.CommonProperty5; }
                set { _data.CommonProperty5 = value; }
            }
        }
        public class C2 : ICommon
        {
            private readonly C _data;
            public C2(C data)
            {
                _data = data;
            }
            public string CommonProperty1
            {
                get { return _data.CommonProperty1; }
                set { _data.CommonProperty1 = value; }
            }
            public int CommonProperty2
            {
                get { return _data.CommonProperty2; }
                set { _data.CommonProperty2 = value; }
            }
            public string CommonProperty3
            {
                get { return _data.CommonProperty3; }
                set { _data.CommonProperty3 = value; }
            }
            public string CommonProperty4
            {
                get { return _data.CommonProperty4; }
                set { _data.CommonProperty4 = value; }
            }
            public string CommonProperty5
            {
                get { return _data.CommonProperty5; }
                set { _data.CommonProperty5 = value; }
            }
        }
            var list = new List<ICommon> { new A2(new A()), new A2(new A()), new B2(new B()), new C2(new C()) };
            foreach (var item in list)
            {
                item.CommonProperty1 = "a";
                item.CommonProperty2 = 2;
                item.CommonProperty3 = "b";
                item.CommonProperty4 = "c";
                item.CommonProperty5 = "d";
            }
