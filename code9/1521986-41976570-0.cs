    string mytext = "William Shakespeare was an English poet, playwright, and actor. He was born on 26 April 1564 in Stratford-upon-Avon. His father was a successful local businessman and his mother was the daughter of a landowner. Shakespeare is widely regarded as the greatest writer in the English language and the world's pre-eminent dramatist. He is often called England's national poet and nicknamed the Bard of Avon. He wrote about 38 plays, 154 sonnets, two long narrative poems, and a few other verses, of which the authorship of some is uncertain. His plays have been translated into every major living language and are performed more often than those of any other playwright.";
                string tofind = "Bard of Avon";
                string resltantSentence = "";
                if (mytext.Contains(tofind))
                {
                    // suppose tofind is InStart / In Middle /In the End of a sentence.
                    // and we want the whole sentence out.
                    //so first split all sentences in arrays
                    string[] sentences = mytext.Split(". ");
                    foreach (string sentence in sentences)
                    {
                        //and find the string in each sentence,
                        // if the string is repeated in multiple sentences, then you can have array of "resltantSentence" instead and comment the break statement.
                        if (sentence.Contains(tofind))
                        {
                            resltantSentence = sentence;
                            break;
                        }
                    }
    
                }
