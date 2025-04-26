using System;

namespace Pong;

public partial class Pong
{
    public void ProgressPhysics(TimeSpan timeDiff)
    {
        // Apply velocity
        Ball.Position += Ball.Velocity;
    }
}
