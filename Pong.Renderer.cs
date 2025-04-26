using ComputeSharp;
using Pong.Models;
using Pong.Shaders;
using System;
using System.Numerics;

namespace Pong;

public partial class Pong
{
    private GraphicsDevice _device;
    private IReadWriteNormalizedTexture2D<float4> _base;
    private ReadOnlyBuffer<AABB> _boxBuffer;
    private ReadOnlyBuffer<float4> _boxColorBuffer;

    private void DrawBase()
    {
        var boxBuffer = _device.AllocateReadOnlyBuffer([
            new AABB(10, 25, 310, 29), // Top
            new AABB(10, 189, 310, 193), // Bottom
            new AABB(10, 25, 14, 189), // Left
            new AABB(306, 25, 310, 193), // Right
        ]);

        var colorBuffer = _device.AllocateReadOnlyBuffer([Float4.One, Float4.One, Float4.One, Float4.One]);
        
        // Draw
        _device.For(_base.Width, _base.Height, new BoxDrawingShader(_base, boxBuffer, colorBuffer));
    }

    public void InitializeRendering()
    {
        _device = GraphicsDevice.GetDefault();
        _base = _device.AllocateReadWriteTexture2D<Rgba32, float4>(320, 200, AllocationMode.Clear);

        DrawBase();

        _boxBuffer = _device.AllocateReadOnlyBuffer<AABB>(3);
        _boxColorBuffer = _device.AllocateReadOnlyBuffer(
        [
            (float4)(Vector4.UnitZ + Vector4.UnitW),
            (float4)(Vector4.UnitX + Vector4.UnitW),
            (float4)(Vector4.UnitY + Vector4.UnitW)
        ]);
    }

    public void Render(IReadWriteNormalizedTexture2D<float4> texture)
    {
        if (texture.GraphicsDevice != _device)
        {
            throw new ArgumentException("Graphics device mismatch");
        }

        _boxBuffer.CopyFrom([Bats[0].AABB, Bats[1].AABB, Ball.AABB]);
        _device.For(texture.Width, texture.Height, new CopyShader(texture, _base));
        _device.For(texture.Width, texture.Height, new BoxDrawingShader(texture, _boxBuffer, _boxColorBuffer));
    }
}
