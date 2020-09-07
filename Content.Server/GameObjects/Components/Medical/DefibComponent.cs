using Content.Shared.Interfaces.GameObjects.Components;
using Robust.Server.Interfaces.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.IoC;

namespace Content.Server.GameObjects.Components.Medical
{
    [RegisterComponent]
    public class DefibComponent: Component, IUse
    {
        [Dependency] private readonly IServerEntityManager _serverEntityManager = default!;
        public override string Name => "Defib";
        public bool UseEntity(UseEntityEventArgs eventArgs)
        {
            throw new System.NotImplementedException();
        }
    }
}
