//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Script/Player/PlayerController.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Player Movements"",
            ""id"": ""dcb2297f-0267-40ce-84fc-6aa10525db61"",
            ""actions"": [
                {
                    ""name"": ""Movements"",
                    ""type"": ""PassThrough"",
                    ""id"": ""06cef7a6-65e0-4640-a439-40ec81d23031"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""cc284f8d-5d50-4b81-a32d-dfd6845a6357"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""ZQSD"",
                    ""id"": ""55adb78a-29be-4753-8e7d-bdb7ed5bb67e"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9e2297fc-e483-45f4-ab66-6034a9a41f76"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5694ef4f-6953-437a-9b4a-01551c1af3ba"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7ee5543e-ec10-4841-b26f-79987b8189c8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""66b08ded-c648-4ae4-beba-51f2f6367c35"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movements"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""edbf74fa-1075-4c92-af41-eac0403b2680"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4fbe4ad-ea90-4fbf-a0d2-646396e9ffa8"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movements
        m_PlayerMovements = asset.FindActionMap("Player Movements", throwIfNotFound: true);
        m_PlayerMovements_Movements = m_PlayerMovements.FindAction("Movements", throwIfNotFound: true);
        m_PlayerMovements_Camera = m_PlayerMovements.FindAction("Camera", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player Movements
    private readonly InputActionMap m_PlayerMovements;
    private List<IPlayerMovementsActions> m_PlayerMovementsActionsCallbackInterfaces = new List<IPlayerMovementsActions>();
    private readonly InputAction m_PlayerMovements_Movements;
    private readonly InputAction m_PlayerMovements_Camera;
    public struct PlayerMovementsActions
    {
        private @PlayerController m_Wrapper;
        public PlayerMovementsActions(@PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movements => m_Wrapper.m_PlayerMovements_Movements;
        public InputAction @Camera => m_Wrapper.m_PlayerMovements_Camera;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovements; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementsActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMovementsActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Add(instance);
            @Movements.started += instance.OnMovements;
            @Movements.performed += instance.OnMovements;
            @Movements.canceled += instance.OnMovements;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
        }

        private void UnregisterCallbacks(IPlayerMovementsActions instance)
        {
            @Movements.started -= instance.OnMovements;
            @Movements.performed -= instance.OnMovements;
            @Movements.canceled -= instance.OnMovements;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
        }

        public void RemoveCallbacks(IPlayerMovementsActions instance)
        {
            if (m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMovementsActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMovementsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMovementsActions @PlayerMovements => new PlayerMovementsActions(this);
    public interface IPlayerMovementsActions
    {
        void OnMovements(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
    }
}
