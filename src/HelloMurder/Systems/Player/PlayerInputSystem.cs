using Bang.Contexts;
using Bang.Entities;
using Bang.Systems;
using Murder.Components;
using Murder;
using HelloMurder.Components;
using HelloMurder.Core.Input;
using Murder.Helpers;
using Murder.Utilities;
using System.Numerics;

namespace HelloMurder.Systems
{
    /// <summary>
    ///     System intended to capture and relay player inputs to entities.
    ///     System is called during frame updates and fixed updates thanks to interfaces.<br/>
    ///     Targets only entities with <b>both</b> PlayerComponent and AgentComponent
    ///     Example usage:<br/>
    ///     1. Poll input system with: <br/>
    ///         Game.Input <see cref="Game.Input"/><br/>
    ///     2. Send entity messages or call extension functions in FixedUpdate within the foreach:<br/>
    ///         entity.SendMessage <see cref="Entity.SendMessage{T}()"/><br/>
    ///         entity.SetImpulse <see cref="MurderEntityExtensions.SetAgentImpulse(Entity)"/><br/>
    /// </summary>
    [Filter(kind: ContextAccessorKind.Read, typeof(PlayerComponent), typeof(AgentComponent))]
    public class PlayerInputSystem : IUpdateSystem, IFixedUpdateSystem
    {

        private Vector2 _cachedInputAxis = Vector2.Zero;

        public void FixedUpdate(Context context)
        {
            foreach (Entity entity in context.Entities)
            {
                bool moved = _cachedInputAxis.HasValue();

                if (moved)
                {
                    Direction direction = DirectionHelper.FromVector(_cachedInputAxis);

                    entity.SetAgentImpulse(_cachedInputAxis, direction);
                }
            }
        }

        public void Update(Context context)
        {
            _cachedInputAxis = Game.Input.GetAxis(InputAxis.Movement).Value;
        }
    }
}
