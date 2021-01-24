    namespace MyWebApplication.Models
    {
        public class Food
        {
            public decimal NRF63 { get; set; }
            public Desc Desc { get; set; }
            public int Index { get; set; }
            public string Style
            {
                get
                {
                    if (NRF63 > 28)
                    {
                        return "green";
                    }
                    else if (NRF63 <= 28 && NRF63 >= 4.66m)
                    {
                        return "#fabb36";
                    }
                    else
                    {
                        return "#c32032";
                    }
                }
            }
        }
        public class Desc
        {
            public string Name { get; set; }
        }
    }
    
