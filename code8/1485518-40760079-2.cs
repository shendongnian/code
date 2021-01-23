    public static class ExtensionMethod
    {
        public static void drawHalo(this Light light, bool value)
        {
            //Get Halo Component
            object halo = light.GetComponent("Halo");
            //Get Enable Halo property
            var haloInfo = halo.GetType().GetProperty("enabled");
            //Enable/Disable Halo
            haloInfo.SetValue(halo, value, null);
        }
    }
