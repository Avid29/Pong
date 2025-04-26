using System.Numerics;

namespace Pong.Models;

/// <summary>
/// A class representing the ball in pong.
/// </summary>
public class Ball
{
    /// <summary>
    /// Gets or sets the position of the ball.
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// Gets or sets the velocity of the ball.
    /// </summary>
    public Vector2 Velocity { get; set; }

    /// <summary>
    /// Gets or sets the size of the ball.
    /// </summary>
    public Vector2 Size { get; set; } = Vector2.One * 8;

    /// <summary>
    /// Gets an AABB for the ball.
    /// </summary>
    public AABB AABB => new(Position, Size);
}
