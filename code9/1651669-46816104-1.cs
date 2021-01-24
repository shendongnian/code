    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Xamarin.Forms;
    using AlarmSQLite.Droid;
    using System.IO;
    using SQLite.Net;
    using SQLite.Net.Async;
    
    [assembly: Dependency(typeof(SQLite_Android))]
    
    namespace AlarmSQLite.Droid
    {
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
    
    
    
        public SQLiteConnection GetConnection()
        {
            var dbName = "AlarmDB.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, dbName);
    
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
    
            return connection;
        }
    
    }
    }
