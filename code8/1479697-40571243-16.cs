    public static class MyPackMethods {
        public static Pack Create(int IDAtSource, IEnumerable<Equipment> equipments) {
            return new Pack() {
                IDAtSource = IDAtSource,
                Equipments = equipments.ToList()
            };
        }
    }
