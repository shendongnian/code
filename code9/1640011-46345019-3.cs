public static class ExtensionMethods {
    public static <b>TEntity</b> DoMagicFunction<b>&lt;TEntity&gt;</b>(<b>this</b> Repository&lt;TEntity&gt; repository)
        <b>where TEntity : User</b> {
        // some magic
        return null; //or another <b>TEntity</b>
    } 
}
