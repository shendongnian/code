    class MyModel
    {
        public int KurumAdi
        {
            ...
            get
            {
                return getKurumAdiByKod(Convert.ToInt32(this.KurumKodu));
            }   
        }
    }
