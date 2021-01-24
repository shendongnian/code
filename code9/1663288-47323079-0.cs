    public static class Helper<T> where T : ICanSave {
        public static async Task<T> Save(T obj) {
            await obj.Save();
            return obj;
        }
    }
