    private final OkHttpClient client;
    public ConfigureTimeouts() throws Exception {
    client = new OkHttpClient.Builder()
        .connectTimeout(100, TimeUnit.SECONDS)
        .writeTimeout(100, TimeUnit.SECONDS)
        .readTimeout(100, TimeUnit.SECONDS)
        .build();
    }
