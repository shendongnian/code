    class CarCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CarElement();
        }
    
        protected override object GetElementKey(ConfigurationElement element)
        {
            var carElement = element as CarElement;
            if (carElement != null)
            {
                var car = (CarElement)carElement;
                return car.Car;
            }
            return null;
        }
    }
    
