        public class City //class
        {
            public string CityName { get; set; }
            public int Temperature { get; set; }
            public City(string name, int temp)//konstruktor 
            {
                this.CityName = name;
                this.Temperature = temp;
            }
            public override string ToString()
            {
                return string.Format("{0} {1}", CityName, Temperature);
            }
        }
