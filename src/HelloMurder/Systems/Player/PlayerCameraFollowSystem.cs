using Bang.Contexts;
using Bang.Systems;
using HelloMurder.Components;
using Murder.Core;
using Murder.Core.Graphics;
using Murder.Utilities;
using System.Numerics;

namespace HelloMurder.Systems.Player
{
    [Filter(typeof(PlayerComponent))]
    internal class PlayerCameraFollowSystem : IFixedUpdateSystem
    {
        public void FixedUpdate(Context context)
        {
            if (!context.HasAnyEntity) 
                return;

            Camera2D camera = ((MonoWorld)context.World).Camera;

            camera.Position = context.Entity.GetGlobalTransform().Vector2 - 
                (new Vector2(camera.HalfWidth, camera.Height/2));
        }
    }
}
