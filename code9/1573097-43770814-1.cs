    public static string Figure(Predicate<dynamic> p)
        {
            dynamic shapeValue;
            do
            {
                shapeValue = Presentation.Present();
            }
            while (p(shapeValue));
            return shapeValue.ToString("R");
        }
