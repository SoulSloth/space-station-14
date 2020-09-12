using Content.Shared.Interfaces.GameObjects.Components;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;

namespace Content.Server.GameObjects.Components.Medical
{
    [RegisterComponent]
    public class DefibPaddles: Component, IDropped
    {
        public override string Name => "DefibPaddles";

        public IEntity defib;

        public void Dropped(DroppedEventArgs eventArgs)
        {
            var myOwner = defib.GetComponent<DefibComponent>();
            myOwner.paddleContianer.Insert(Owner);
        }
    }
}
