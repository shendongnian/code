    public static string Figure(Predicate p)
        {
            dynamic shapeValue;
            do
            {
                shapeValue = Presentation.Present();
            }
            while (p());
            return shapeValue.ToString("R");
        }
