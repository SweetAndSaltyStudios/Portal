using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sweet_And_Salty_Studios
{
    [CreateAssetMenu(fileName ="New Input Data", menuName ="Sweet & Salty Studios/New Input Data")]
    public class InputData : ScriptableObject
    {
        #region VARIABLES

        public InputAction Movement_Action;
        public InputAction Look_Action;
        public InputAction Jump_Action;
        public InputAction Run_Action;
        public InputAction Crouch_Action;

        #endregion VARIABLES

        #region PROPERTIES

        public bool IsRunTriggered
        {
            get
            {
                return Run_Action.triggered;
            }
        }

        public bool IsCrouchTriggered
        {
            get
            {
                return Crouch_Action.triggered;
            }
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void OnEnable()
        {
            Movement_Action.Enable();
            Look_Action.Enable();
            Jump_Action.Enable();
            Run_Action.Enable();
            Crouch_Action.Enable();
        }

        private void OnDisable()
        {
            Movement_Action.Disable();
            Look_Action.Disable();
            Jump_Action.Disable();
            Run_Action.Disable();
            Crouch_Action.Disable();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void RegisterMovementAction(Action onStarted, Action onPerformed, Action onCanceled)
        {
            Movement_Action.started += context =>
            {
                onStarted?.Invoke();
            };

            Movement_Action.performed += context =>
            {
                onPerformed?.Invoke();
            };

            Movement_Action.canceled += context =>
            {
                onCanceled?.Invoke();
            };
        }

        public void RegisterLookAction(Action onStarted, Action onPerformed, Action onCanceled)
        {
            Look_Action.started += context =>
            {
                onStarted?.Invoke();
            };

            Look_Action.performed += context =>
            {
                onPerformed?.Invoke();
            };

            Look_Action.canceled += context =>
            {
                onCanceled?.Invoke();
            };
        }

        public void RegisterJumpAction(Action onStarted = null, Action onPerformed = null, Action onCanceled = null)
        {
            Jump_Action.started += context =>
            {
                onStarted?.Invoke();
            };

            Jump_Action.performed += context =>
            {
                onPerformed?.Invoke();
            };

            Jump_Action.canceled += context => 
            {
                onCanceled?.Invoke();
            };
        }

        public void RegisterRunAction(Action onStarted = null, Action onPerformed = null, Action onCanceled = null)
        {
            Run_Action.started += context =>
            {
                onStarted?.Invoke();
            };

            Run_Action.performed += context =>
            {
                onPerformed?.Invoke();
            };

            Run_Action.canceled += context =>
            {
                onCanceled?.Invoke();
            };
        }

        public void RegisterCrouchAction(Action onStarted, Action onPerformed, Action onCanceled)
        {
            Run_Action.started += context =>
            {
                onStarted?.Invoke();
            };

            Run_Action.performed += context =>
            {
                onPerformed?.Invoke();
            };

            Run_Action.canceled += context =>
            {
                onCanceled?.Invoke();
            };
        }

        #endregion CUSTOM_FUNCTIONS
    }
}

