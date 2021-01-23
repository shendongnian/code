            StringBuilder s = new StringBuilder();
            s.Append(@"<div id=menu>
                        <ul>
                        <li>Dahboard
                            <ul>
                                <li> View1 </li>
                                <li> View2 </li>
                            </ul>
                        </li>
                        </ul>
                    </div> "); //you can alter this string dynamically
            mainDiv.InnerHtml = s.ToString();
