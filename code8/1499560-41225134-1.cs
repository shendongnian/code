		static readonly List<RunDays> s_runDays = Enum.GetValues(typeof(RunDays)).Cast<RunDays>().ToList();
		static RunDays Parse(string s)
		{
			if (String.IsNullOrWhiteSpace(s)) throw new ArgumentNullException(nameof(s));
			if (s.Length != 7) throw new ArgumentOutOfRangeException(nameof(s));
			var retval = RunDays.None;
			for (int i = 0; i < s.Length; i++)
				if (Int32.TryParse(s[i].ToString(), out var result) && (result > 0))
					retval |= s_runDays[i+1];
			return retval;		
		}
