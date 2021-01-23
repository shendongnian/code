    public class Alerter<T>
    {
        private readonly WeatherType _weatherType;
    
        public Alerter(WeatherType weatherType)
        {
            _weatherType = weatherType;
        }
    
        public void SendAlerts()
        {
            var people = PersonRepository.GetPeople(_weatherType);
    
            foreach (Person person in people)
            {
                var e = (T)Activator.CreateInstance(typeof(T));
                e.SendToPerson(person, _weatherType);
            }
        }
    }
