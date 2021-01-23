    static string closestColor1(List<Color> colors, Color target)
        {
            var hue1 = target.GetHue();
            var diffs = colors.Select(n => getHueDistance(n.GetHue(), hue1));
            var diffMin = diffs.Min(n => n);
            var x = diffs.ToList().FindIndex(n => n == diffMin);
    
            Color c = colors[x];
    
            float h = c.GetHue();
            float s = c.GetSaturation();
            float b = (c.R * 0.299f + c.G * 0.587f + c.B * 0.114f) / 256f;
    
            string name = s < 0.35f ? "pale " : s > 0.8f ? "vivid " : "";
            name += b < 0.35f ? "dark " : b > 0.8f ? "light " : "";
    
            name += colors[x].ToString();
    
            return name;
        }
