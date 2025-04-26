using System.Numerics;

namespace Pong.Models;

/// <summary>
/// A class representing the bat in pong.
/// </summary>
public class Bat
{
    private static readonly Vector2 BAT_SIZE = new Vector2(6, 40);

    /// <summary>
    /// Initializes a new instance of the <see cref="Bat"/> class.
    /// </summary>
    /// <param name="x">The X coordinate of the bat.</param>
    public Bat(float x)
    {
        Position = new Vector2(x, 0);
        Size = BAT_SIZE;
    }

    /// <summary>
    /// Gets or sets the position of the bat.
    /// </summary>
    public Vector2 Position { get; set; }

    /// <summary>
    /// Gets or sets the size of the bat.
    /// </summary>
    public Vector2 Size { get; set; }

    /// <summary>
    /// Gets an AABB for the bat.
    /// </summary>
    public AABB AABB => new(Position, Size);
}
