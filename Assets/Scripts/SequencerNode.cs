public class SequencerNode : CompositeNode
{
    int current;

    protected override void OnStart()
    {
        current = 0;
    }

    protected override void OnStop()
    {
        
    }

    protected override State OnUpdate()
    {
        var child = children[current];
        switch (child.Update())
        {
            case State.RUNNING:
                return State.RUNNING;
            case State.SUCCESS:
                current++;
                break;
            case State.FAILURE:
                return State.FAILURE;
        }

        return current == children.Count ? State.SUCCESS : State.RUNNING;
    }
}
