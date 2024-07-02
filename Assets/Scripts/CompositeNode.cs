using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class CompositeNode : Node
{
    [HideInInspector] public List<Node> children = new List<Node>();

    public override Node Clone()
    {
        CompositeNode node = Instantiate(this);
        node.children = children.ConvertAll(child => child.Clone());
        return node;
    }
}
