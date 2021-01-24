     public class ResponseData<T> where T : class
        {
            public int current { get; set; } // current page
            public int rowCount { get; set; } // rows per page
            public T rows { get; set; } // items
            public int total { get; set; } // total rows for whole query
        }
