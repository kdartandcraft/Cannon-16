// GENERATED AUTOMATICALLY FROM 'Assets/Input/CannonControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CannonControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CannonControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CannonControls"",
    ""maps"": [
        {
            ""name"": ""Cannon"",
            ""id"": ""4da696d5-9095-41fc-b0a7-3a5102f362c5"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""7185dcc1-aefd-4497-b3d2-598fc6ade282"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""beed2dc3-71df-4fa3-b833-3c04396719d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f85289e7-7068-4ce0-9e81-0d240846bbce"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72bf01ca-bb30-4eca-a58d-1713d851b425"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Cannon
        m_Cannon = asset.FindActionMap("Cannon", throwIfNotFound: true);
        m_Cannon_Rotate = m_Cannon.FindAction("Rotate", throwIfNotFound: true);
        m_Cannon_Fire = m_Cannon.FindAction("Fire", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Cannon
    private readonly InputActionMap m_Cannon;
    private ICannonActions m_CannonActionsCallbackInterface;
    private readonly InputAction m_Cannon_Rotate;
    private readonly InputAction m_Cannon_Fire;
    public struct CannonActions
    {
        private @CannonControls m_Wrapper;
        public CannonActions(@CannonControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Cannon_Rotate;
        public InputAction @Fire => m_Wrapper.m_Cannon_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Cannon; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CannonActions set) { return set.Get(); }
        public void SetCallbacks(ICannonActions instance)
        {
            if (m_Wrapper.m_CannonActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_CannonActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_CannonActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_CannonActionsCallbackInterface.OnRotate;
                @Fire.started -= m_Wrapper.m_CannonActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_CannonActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_CannonActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_CannonActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public CannonActions @Cannon => new CannonActions(this);
    public interface ICannonActions
    {
        void OnRotate(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
