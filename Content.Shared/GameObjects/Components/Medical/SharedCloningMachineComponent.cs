﻿using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameObjects.Components.UserInterface;
using Robust.Shared.Serialization;

namespace Content.Shared.GameObjects.Components.Medical
{
    public class SharedCloningMachineComponent : Component
    {
        public override string Name => "CloningMachine";

        [Serializable, NetSerializable]
        public class CloningMachineBoundUserInterfaceState : BoundUserInterfaceState
        {
            public readonly float Progress;
            public readonly bool Working;

            public CloningMachineBoundUserInterfaceState(float progress, bool working)
            {
                Progress = progress;
                Working = working;
            }
        }

        [Serializable, NetSerializable]
        public enum CloningMachineUIKey
        {
            Key
        }

        [Serializable, NetSerializable]
        public enum CloningMachineVisuals
        {
            Status
        }

        [Serializable, NetSerializable]
        public enum CloningMachineStatus
        {
            Idle,
            Cloning,
            Done
        }

        [Serializable, NetSerializable]
        public enum UiButton
        {
            Clone
        }

        [Serializable, NetSerializable]
        public class UiButtonPressedMessage : BoundUserInterfaceMessage
        {
            public readonly UiButton Button;

            public UiButtonPressedMessage(UiButton button)
            {
                Button = button;
            }
        }
    }
}
