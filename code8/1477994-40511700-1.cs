    public partial class Form1 : Form
    {
        Page_1 pageA = new Page_1();
        pageA.PerformSomeLogic();
        pageA.Continue();
        pageB = new Page_1(); <-- this can be Page_1() or better yet, renamed to ContentPage or something that better represents the type of page rather than the page number.
        pageB.PerformSomeLogic();
        pageB.Continue();
