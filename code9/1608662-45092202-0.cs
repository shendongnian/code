class TestObject{
    string name = "phil";
    
    public void SetName(string name){
          this.name = name;
    }
    <b>public TestObject Clone () {
        var result = new TestObject();
        result.name = this.name;
        return result;
    }</b>
}
