using ComputeSharp;

namespace Pong.Shaders;

[GeneratedComputeShaderDescriptor]
[ThreadGroupSize(DefaultThreadGroupSizes.XY)]
public readonly partial struct CopyShader(IReadWriteNormalizedTexture2D<float4> destination, IReadWriteNormalizedTexture2D<float4> source) : IComputeShader
{
    public void Execute()
    {
        destination[ThreadIds.XY] = source[ThreadIds.XY];
    }
}
