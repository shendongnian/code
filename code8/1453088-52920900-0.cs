    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace TestDLApp.Utilities.Extensions
    {
    	public static class ObjectToTreeView
    	{
    		private sealed class IndexContainer
    		{
    			private int _n;
    			public int Inc() => _n++;
    		}
    
    		private static void FillTreeView(TreeNode node, JToken tok, Stack<IndexContainer> s)
    		{
    			if (tok.Type == JTokenType.Object)
    			{
    				TreeNode n = node;
    				if(tok.Parent != null)
    				{
    					if(tok.Parent.Type == JTokenType.Property)
    					{
    						n = node.Nodes.Add($"{((JProperty)tok.Parent).Name} <{tok.Type.ToString()}>");
    					}
    					else
    					{
    						n = node.Nodes.Add($"[{s.Peek().Inc()}] <{tok.Type.ToString()}>");
    					}
    				}
    				s.Push(new IndexContainer());
    				foreach (var p in tok.Children<JProperty>())
    				{
    					FillTreeView(n, p.Value, s);
    				}
    				s.Pop();
    			}
    			else if (tok.Type == JTokenType.Array)
    			{
    				TreeNode n = node;
    				if(tok.Parent != null)
    				{
    					if (tok.Parent.Type == JTokenType.Property)
    					{
    						n = node.Nodes.Add($"{((JProperty)tok.Parent).Name} <{tok.Type.ToString()}>");
    					}
    					else
    					{
    						n = node.Nodes.Add($"[{s.Peek().Inc()}] <{tok.Type.ToString()}>");
    					}
    				}
    				s.Push(new IndexContainer());
    				foreach (var p in tok)
    				{
    					FillTreeView(n, p, s);
    				}
    				s.Pop();
    			}
    			else
    			{
    				var name = string.Empty;
    				var value = JsonConvert.SerializeObject(((JValue)tok).Value);
    
    				if (tok.Parent.Type == JTokenType.Property)
    				{
    					name = $"{((JProperty)tok.Parent).Name} : {value}";
    				}
    				else
    				{
    					name = $"[{s.Peek().Inc()}] : {value}";
    				}
    
    				node.Nodes.Add(name);
    			}
    		}
    
    		public static void SetObjectAsJson<T>(this TreeView tv, T obj)
    		{
    			tv.BeginUpdate();
    			try
    			{
    				tv.Nodes.Clear();
    
    				var s = new Stack<IndexContainer>();
    				s.Push(new IndexContainer());
    				FillTreeView(tv.Nodes.Add("ROOT"), JsonConvert.DeserializeObject<JToken>(JsonConvert.SerializeObject(obj)), s);
    				s.Pop();
    			}
    			finally
    			{
    				tv.EndUpdate();
    			}
    		}
    	}
    }
