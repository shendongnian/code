    public static implicit operator Node<double>(Node<T> node) {
        Node<double> destinationNode = new Node<double>();
        destinationNode.Content = Convert.ToDouble(node.Content);
        return destinationNode;
    }
