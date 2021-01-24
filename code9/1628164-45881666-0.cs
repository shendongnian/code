    /// <summary>
    /// Provides JSON Serialize and Deserialize.
    /// </summary>
    public interface IJsonSerializer : ISerializer {
    }
    /// <summary>
    /// Serialization interface that supports serialize and deserialize methods
    /// </summary>
    public interface ISerializer {
        /// <summary>
        /// Serialize the specified object into a string
        /// </summary>
        /// <param name="obj">object to serialize</param>
        string Serialize(object obj);
        /// <summary>
        /// Deserialize a string into a typed object
        /// </summary>
        /// <typeparam name="T">type of object</typeparam>
        /// <param name="input">input string</param>
        T Deserialize<T>(string input);
    }
