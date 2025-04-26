using ComputeSharp;
using Pong.Models;

namespace Pong.Shaders;

[GeneratedComputeShaderDescriptor]
[ThreadGroupSize(DefaultThreadGroupSizes.XY)]
public readonly partial struct BoxDrawingShader(IReadWriteNormalizedTexture2D<float4> texture, ReadOnlyBuffer<AABB> boxes, ReadOnlyBuffer<float4> colors) : IComputeShader
{
    public void Execute()
    {
        // Check each box in order
        for (int i = 0; i < boxes.Length; i++)
        {
            // Check for box collision
            var box = boxes[i];
            if (!box.Contains((float2)ThreadIds.XY))
                continue;

            // If yes, apply the box color
            texture[ThreadIds.XY] = colors[i];
        }
    }
}
