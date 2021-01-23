    public class FormOptimize : System.Windows.Forms.Form
    {
        private callCplex()
        {
            //Misc code
            cplex.Use(new Cplex_ContinuousCallback(this)); // <-- passing `this`
            cplex.Solve()
            //Misc code
        }
        public void Update_OptimizeStatusbarPanel(String strText)
        {
            if (statusBarPanel_1.InvokeRequired)
                statusBarPanel_1.Invoke(Action<string>(Update_OptimizeStatusbarPanel), strText);
            else
            {
                statusBarPanel_1.Text = strText;
                statusBar1.Refresh();
            }
        }
                
        internal class Cplex_ContinuousCallback : Cplex.ContinuousCallback
        {
            FormOptimize _formOptimize;
            public Cplex_ContinuousCallback(FormOptimize formOptimize)
            {
                this._formOptimize = formOptimize;
            }
            
            public override void Main()
            {
                //...
                _formOptimize.Update_OptimizeStatusbarPanel(String.Format("Running Optimization: {0} iterations ", Niterations));
            }
        }
    }
