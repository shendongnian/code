        IAsyncOperation<bool> result = await Task.Run(() => IAsyncTrue.GetBigList());
        ...
        } /// end class
        public class IAsyncTrue
        {
            public static bool GetBigList()
            {
                // Tons of over peoples work to do in here!
                return true;
            }
}
