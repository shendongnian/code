        Dim markup As XElement
        markup = <a href='#'>
                     <span>
                     outer content
                    <span>inner content</span>
                     </span>
                 </a>
        Dim newmarkup As XElement = New XElement(markup)
        newmarkup.<span>.DescendantNodes.Remove()
        newmarkup.<span>.Value = "("
        For Each el As XNode In markup.<span>.Nodes
            newmarkup.<span>.Nodes.LastOrDefault.AddAfterSelf(el)
        Next
        newmarkup.<span>.Nodes.LastOrDefault.AddAfterSelf(")")
