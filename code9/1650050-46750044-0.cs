    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NCalc;
    public partial class Form1 : Form
    {
        public ExpressionString expressi = new ExpressionString("pow([x],3)/(exp(x)-1)");
        public void FunctionInt(double x, double xminusa, double bminusx, ref double y, object obj)
        {
            Expression e = new Expression(expressi.expression, EvaluateOptions.IgnoreCase);
            e.Parameters["x"] = x;
            object result = e.Evaluate();
            y = Convert.ToDouble(result);
        }
    }
