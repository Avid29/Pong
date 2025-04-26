using System.Numerics;

namespace Pong.Models;

/// <summary>
/// A struct representating an Axis-Aligned-Bounding-Box.
/// </summary>
/// <remarks>
/// Uses public fields instead of properties because it must be usable in <see cref="IComputeShader"/>s.
/// </remarks>
public struct AABB(float2 pos, float2 size)
{
    public AABB(float xMin, float yMin, float xMax, float yMax) : this(new float2(xMin, yMin), new float2(xMax - xMin, yMax - yMin))
    {
    }

    /// <summary>
    /// Gets or sets the simple position coordinate of the AABB.
    /// </summary>
    public float2 Position = pos;

    /// <summary>
    /// Gets or sets the size of the AABB.
    /// </summary>
    public float2 Size = size;

    /// <summary>
    /// Gets the center coordinates of the AABB.
    /// </summary>
    public readonly Vector2 Center => (Vector2)Position + ((Vector2)Size / 2);

    /// <summary>
    /// Gets the top left coordinates of the AABB.
    /// </summary>
    public readonly Vector2 TopLeft => Position;

    /// <summary>
    /// Gets the bottom right coordinates of the AABB.
    /// </summary>
    public readonly Vector2 BottomRight => TopLeft + (Vector2)Size;
    
    public bool Contains(float2 pos)
    {
        // Check X bounds
        if (pos.X < Position.X || pos.X > (Position + Size).X)
            return false;

        // Check Y bounds
        if (pos.Y < Position.Y || pos.Y > (Position + Size).Y)
            return false;

        return true;
    }
}
