using ComputeSharp;
using ComputeSharp.WinUI;
using Pong.Models;
using System;
using System.Numerics;

namespace Pong;

/// <summary>
/// An <see cref="IShaderRunner"/>
/// </summary>
public partial class Pong : IShaderRunner
{
    private TimeSpan _prev = TimeSpan.Zero;

    /// <summary>
    /// Initializes a new instance of the <see cref="Pong"/> class.
    /// </summary>
    public Pong()
    {
        Ball = new Ball();
        Bats =
        [
            new Bat(19),
            new Bat(295),
        ];

        InitializeRendering();
    }

    /// <summary>
    /// Gets or sets the ball.
    /// </summary>
    public Ball Ball { get; set; }

    /// <summary>
    /// Gets or sets the array of bats.
    /// </summary>
    public Bat[] Bats { get; set; }

    /// <summary>
    /// Contains the main game loop. Invoked each time the swap-chain requests a frame.
    /// </summary>
    /// <inheritdoc/>
    public bool TryExecute(IReadWriteNormalizedTexture2D<float4> texture, TimeSpan timespan, object? parameter)
    {
        // Calculate time change
        TimeSpan timeDiff = timespan - _prev;
        _prev = timespan;

        // Progress physics model
        ProgressPhysics(timeDiff);

        // Render update
        Render(texture);

        return true;
    }
}
