using Unity.Entities;

[GenerateAuthoringComponent]
public struct Unit_Initializer_Component : IComponentData
{
    public int xGridCount;
    public int zGridCount;
    public float baseOffset;
    public float xPadding;
    public float zPadding;
    public Entity prefabToSpawn;
}
