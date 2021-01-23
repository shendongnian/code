    public class AliasesNode:TreeNode
    {
        public AliasesNode(Aliases al)
        {
            this.Text = String.Format("{0} - {1}", al.AliasName, al.AliasValue);   
        }
    
        public void Click()
        {
            MessageBox.Show(new String(this.Text.Reverse().ToArray()));
        }                
    }
