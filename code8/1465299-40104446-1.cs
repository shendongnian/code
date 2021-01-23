    public class PlayerToTournamentRegistered : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(values[0] is Student) || !(values[1] is Tournament))
            {
                return false;
            }
            Tournament myTournament = (Tournament)values[1];
            Student myPlayer = (Student)values[0];
            if (myTournament.Participants.Contains(myPlayer))
                return true;
            return false;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
