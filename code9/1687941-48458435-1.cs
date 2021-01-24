    enum PassStrength
    {
        Unchecked = 0, // Enums should always have an empty value for initialisation.
        VeryWeak = 1,
        Weak = 2,
        Good = 3,
        Strong = 4,
        VeryStrong = 5
    }
    public string GetPasswordStrenght1()
    {
        string valor = GetPasswordStrength();
        switch(valor)
        {
            case "Very Weak":
                return Convert.ToString(PassStrength.VeryWeak);
            case "Weak":
                return Convert.ToString(PassStrength.Weak);
            case "Good":
                return Convert.ToString(PassStrength.Good);
            case "Strong":
                return Convert.ToString(PassStrength.Strong);
            case "Very Strong":
                return Convert.ToString(PassStrength.VeryStrong);
            default:
                return Convert.ToString(PassStrength.Unchecked);
        }
    }
