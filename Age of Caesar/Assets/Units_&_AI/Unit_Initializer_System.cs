using Unity.Entities;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Transforms;
using UnityEngine;


public partial class Unit_Initializer_System : SystemBase
{
    BeginInitializationEntityCommandBufferSystem ei_ECB;
    protected override void OnCreate()
    {
        ei_ECB = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    protected override void OnUpdate()
    {
        var ecb = ei_ECB.CreateCommandBuffer().AsParallelWriter();
        Entities.WithBurst(synchronousCompilation:true);
        Entities.ForEach((Entity e, int entityInQueryIndex, in Unit_Initializer_Component uic, in LocalToWorld ltw) =>
        {
            for(int i = 0; i < uic.xGridCount; i++)
            {
                for(int j = 0; j < uic.zGridCount; j++)
                {
                    Debug.Log("spawning");
                    Debug.Log(uic.xGridCount + " and " + uic.zGridCount);
                    Entity defEntity = ecb.Instantiate(entityInQueryIndex, uic.prefabToSpawn);
                    float3 position = new float3(i * uic.xPadding, uic.baseOffset, j * uic.zPadding);
                    ecb.SetComponent(entityInQueryIndex, defEntity, new Translation { Value = position });
                }
            }
            ecb.DestroyEntity(entityInQueryIndex, e);
        }).WithoutBurst().Run();
        ei_ECB.AddJobHandleForProducer(Dependency);
    }

}
