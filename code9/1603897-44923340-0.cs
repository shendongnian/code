    public void IsValid(string applicationNumber)
    {
        if (!applicationNumber.Length.Equals(15))
        {
            throw new ApplicationException(string.Format("De lengte van de rubriek: aanvraagnummer [001.], met waarde {0}, is niet valide.", applicationNumber));
        } else {
            applicationNumberExpression = "qwerty123456789";
    
            if (!applicationNumberExpression.IsMatch(applicationNumber))
            {
                throw new ApplicationException(string.Format("Het aanvraagnummer [001.] met waarde {0} is niet conform de voorgeschreven structuur.", applicationNumber));
            }
        }
    }
