using System.Linq;
using Content.Server.GameObjects.Components.Items.Storage;
using Content.Server.Interfaces.GameObjects.Components.Items;
using Content.Shared.Interfaces.GameObjects.Components;
using Robust.Server.GameObjects.Components.Container;
using Robust.Server.Interfaces.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Map;

namespace Content.Server.GameObjects.Components.Medical
{
    [RegisterComponent]
    public class DefibComponent : Component, IUse, IDropped
    {
        [Dependency] private readonly IServerEntityManager _serverEntityManager = default!;
        public override string Name => "Defib";

        public ContainerSlot paddleContianer = default!;

        public IEntity defibPaddles = default!;

        public override void Initialize()
        {
            base.Initialize();
            paddleContianer = ContainerManagerComponent.Ensure<ContainerSlot>($"{Name}-paddleContainer", Owner);
            paddleContianer.Insert(
                    _serverEntityManager.SpawnEntity("DefibrillatorPaddles",Owner.Transform.Coordinates));
            paddleContianer.ContainedEntity.GetComponent<DefibPaddles>().defib = Owner;
        }

        public bool UseEntity(UseEntityEventArgs eventArgs)
        {

            //TODO: No paddle message
            if (paddleContianer.ContainedEntity == null) return false;

            var hands = eventArgs.User.GetComponent<IHandsComponent>();
            var firstInactiveHand = hands.GetFirstInactiveEmptyHand();

            //TODO: Hands are full message.
            if (firstInactiveHand == null) return false;

            var paddles = paddleContianer.ContainedEntity;
            hands.PutInHand(paddles.GetComponent<ItemComponent>(), firstInactiveHand!, false);

            defibPaddles = paddles;


            return true;
        }

        public void Dropped(DroppedEventArgs eventArgs)
        {
            if (defibPaddles != null) paddleContianer.Insert(defibPaddles);
        }
    }
}
