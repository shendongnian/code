    DateTime answer;
    DateTime today = DateTime.Today;
    do
    {
        if (years / planetyeardata[0] > 1)
        {
            var daysToAdd = (1 - (days / 87.97 - (days / 87.97)));
            if (daysToAdd > 0 && DateTime.MaxValue.Subtract(today).TotalDays > daysToAdd)
                throw new Exception(string.Format("Can't add {0} days to {1}", daysToAdd, today));
            if (daysToAdd < 0 && today.Subtract(DateTime.MinValue).TotalDays > daysToAdd)
                throw new Exception(string.Format("Can't add {0} days to {1}", daysToAdd, today));
            answer = today.AddDays(87.97 *daysToAdd );
            mnbd.Text = answer.ToString();
            today = answer;
        }
        else
        {
            var daysToAdd = (1 - (days / 87.97 - (days / 87.97)));
            if (daysToAdd > 0 && DateTime.MaxValue.Subtract(today).TotalDays > daysToAdd)
                throw new Exception(string.Format("Can't add {0} days to {1}", daysToAdd, today));
            if (daysToAdd < 0 && today.Subtract(DateTime.MinValue).TotalDays> daysToAdd)
                throw new Exception(string.Format("Can't add {0} days to {1}", daysToAdd, today));
            answer = today.AddDays(87.97 * (1 - days / 87.97));    // + (224.7 * (1 - days / 224.7) * 24 * 3600 * 1000));
            today = answer;
            mnbd.Text = answer.ToString();
        }
    } while (today <= answer);
