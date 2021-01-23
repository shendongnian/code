    using StackExchange.Redis;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    namespace RedisTest
    {
    
        class Program
        {
    
            #region Diagnostics
    
            static void w(string msg = "")
            {
                System.Console.WriteLine(msg);
            }
    
            static void w(string fmt, params object [] p)
            {
                string msg = string.Format(fmt, p);
                w(msg);
            }
    
            #endregion Diagnostics
    
    
    
    
            //
            // Use of redis:
            //
            // https://github.com/StackExchange/StackExchange.Redis/blob/master/Docs/Basics.md
            // https://redis.io/commands
            //
    
    
            static string string_key = "key_string";
            static string string_val = "Mary had a little lamb. She ate it.";
    
            static string int_key = "key_int";
            static string int_val = "100";
    
            static string non_existent_key = "sdlfhsfhshdfhsdf";
    
    
            static void Main(string[] args)
            {
                ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
                w("Connected to Redis.");
                w();
    
                IDatabase redis_db = redis.GetDatabase();
    
                // Storage and retrieval of a string
                redis_db.StringSet(string_key, string_val);
                var redis_val = redis_db.StringGet(string_key);
                string sval = (string) redis_val;
                w("String value retrieved: {0}", sval);
    
    
                // Storage of an int; decrementing and incrementing it
                redis_db.StringSet(int_key, int_val);
                redis_db.StringDecrement(int_key, 15);
                redis_val = redis_db.StringGet(int_key);
                int iVal = (int)redis_val;
                w("Int retrieved: {0}", iVal);
    
                redis_db.StringIncrement(int_key, 55);
                redis_val = redis_db.StringGet(int_key);
                iVal = (int)redis_val;
                w("Int retrieved: {0}", iVal);
    
    
                // Retrieving a non-existent value
                redis_val = redis_db.StringGet(non_existent_key);
                if (redis_val.IsNull)
                {
                    w("Null value retrieved.");
                }
    
                
                // Check for existence of a key
    
                bool b = redis_db.KeyExists(int_key);
                if (b)
                {
                    w("Key {0} exists.", int_key);
                }
    
                b = redis_db.KeyExists(non_existent_key);
                if (!b)
                {
                    w("Key {0} does not exist.", int_key);
                }
    
    
    
    
                // Delete a key
                redis_db.KeyDelete(string_key);
                redis_db.KeyDelete(int_key);
    
                // Delete all keys - only available from command line: https://redis.io/commands/flushdb
    
    
                w();
                redis.Close();
                redis.Dispose();
                w("Disconnected from Redis.");
    
                w();
                w("Hit RETURN to end.");
                System.Console.ReadLine();
            }
    
        } // class Program
    
    } // namespace RedisTest
