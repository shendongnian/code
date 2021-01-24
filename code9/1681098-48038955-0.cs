        Func<string, IEnumerable<Color>> validColorsRule = s =>
        {
            switch (s)
            {
                case "BLUE": return colors.Except(new[] { Color.Blue });
                case "RED": return colors.Except(new[] { Color.Red });
                case "BLACK": return colors.Except(new[] { Color.Black });
                case "GREEN": return colors.Except(new[] { Color.Green });
                default: throw new NotSupportedException();
            }
        };
