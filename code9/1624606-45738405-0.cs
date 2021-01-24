    class Database {
    private static final String Username = "username";
    private static final String Password = "password";
    private static final String Name = "name";
    private static final String Email = "email";
    private static final String ConfirmedPassword = "confirmed_password";
    private static final String TAG = "DBAdapter";
    private static final String DATABASE_NAME = "DB_Skyetek_Login.db";
    private static final String DATABASE_TABLE = "tblLogin";
    private static final int DATABASE_VERSION = 1;
    private static final String DATABASE_CREATION =
            "create table " + DATABASE_TABLE + " ( registerid INTEGER PRIMARY KEY AUTOINCREMENT, "
                    + " username text not null, "
                    + " name text not null, " +
                    " email text not null, " +
                    " confirmed_password text not null, " +
                    " password text not null);";
    private SQLiteDatabase writableDatabase;
    private MyDatabase database;
    public Database(Context context) {
        database = new MyDatabase(context);
        writableDatabase = database.getWritableDatabase();
    }
    private static class MyDatabase extends SQLiteOpenHelper {
        public MyDatabase(Context context) {
            super(context, DATABASE_NAME, null, DATABASE_VERSION);
        }
        public void onCreate(SQLiteDatabase db) {
            db.execSQL(DATABASE_CREATION);
        }
        @Override
        public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
            db.execSQL("DROP TABLE IF EXISTS " + DATABASE_TABLE);
            onCreate(db);
        }
    }
    public long InsertRegisterDetails(String name, String username, String password, String email, String confirm_password) {
        ContentValues RegisterValues = new ContentValues();
        RegisterValues.put(Username, username);
        RegisterValues.put(Name, name);
        RegisterValues.put(Email, email);
        RegisterValues.put(Password, password);
        RegisterValues.put(ConfirmedPassword, confirm_password);
        return writableDatabase.insert(DATABASE_TABLE, null, RegisterValues);
    }
    public void closeDatabase() {
        if (database != null)
            database.close();
    }
    }
    
