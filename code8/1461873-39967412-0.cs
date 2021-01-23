			TextSelection selection = (TextSelection)typeof(PasswordBox).GetProperty("Selection", BindingFlags.Instance | BindingFlags.NonPublic).GetMethod.Invoke(textBox, null);
			Type tTextRange = selection.GetType().GetInterfaces().Where(x => x.Name == "ITextRange").FirstOrDefault();
			object oStart = tTextRange.GetProperty("Start").GetMethod.Invoke(selection, null);
			object oEnd = tTextRange.GetProperty("End").GetMethod.Invoke(selection, null);
			MethodInfo mi = oStart.GetType().GetProperty("Offset", BindingFlags.Instance | BindingFlags.NonPublic).GetMethod;
			int nStart = (int)mi.Invoke(oStart, null);
			int nEnd = (int)mi.Invoke(oEnd, null);
			System.Diagnostics.Debug.WriteLine(nStart + " ==> " + nEnd);
