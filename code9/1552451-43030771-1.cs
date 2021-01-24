    var questions = new List<Question>();
    var Question lastQuestion = null;
    foreach (string line in File.ReadLines(path)) {
        if (line.StartsWith("*")) {
            // We have a new question. Create a question object and add it to the list.
            lastQuestion = new Question(line.Substring(1));
            questions.Add(lastQuestion);
        } else if (lastQuestion != null) {
            // We have a term related to the last question. Add it to the last question.
            // Split the line at the equal sign.
            string[] parts = line.Split("=", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 0) {
                // We have at least one part that is not empty. Lets assume its the part before
                // the "=". If we have a second part, insert it as well, otherwise insert null.
                var choice = new Choice(parts[0], parts.Length > 1 ? parts[1] : null);
                lastQuestion.Add(choice); 
            }
        }
    }
