using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class PlayerEngine : MonoBehaviour
    {
        #region VARIABLES

        private Transform cameraRig;

#pragma warning disable 649

        [Space]
        [Header("Movement")]
        [SerializeField] private float walkSpeed = 4;
        [SerializeField] private float runSpeed = 8;
        private float movementSpeed = 0;

        [Space]
        [Header("Jump")]
        [SerializeField] private float jumpMultiplier = 10;

        [Space]
        [Header("Slope")]
        [SerializeField] private float smooth = 0.15f;
        [SerializeField] private float sensitivity = 10;

        [Space]
        [Header("Interaction")]
        [SerializeField] private Interactable previouslySelectedInteractable;
        [SerializeField] private Interactable currentSelectedInteractable;
        [SerializeField] private float interactionDistance = 10;
        [SerializeField] private LayerMask interactableMask;

#pragma warning restore 649

        private ISelectionResponse selectionResponse;

        private float verticalLookRotation;

        private Vector3 moveAmount;
        private Vector3 smoothMoveVelocity;

        private Rigidbody rb;
        private Camera mainCamera;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            mainCamera = Camera.main;
            cameraRig = mainCamera.transform;

            selectionResponse = GetComponent<ISelectionResponse>();
        }

        private void Start()
        {
            movementSpeed = walkSpeed;

            InitializeActions();
        }

        private void Update()
        {
            HandleSelection();

            HandleLookRotation();
            HandleMovement();
        }

        private void HandleSelection()
        {
            if(currentSelectedInteractable != null)
            {
                selectionResponse.OnDeselected(currentSelectedInteractable);
            }

            var ray = mainCamera.ScreenPointToRay(new Vector2(Screen.width, Screen.height) * 0.5f);

            currentSelectedInteractable = null;

            if(Physics.Raycast(ray, out RaycastHit hitInfo, interactionDistance, interactableMask))
            {
                var hittedInteractable = hitInfo.transform.GetComponent<Interactable>();

                if(hittedInteractable != null)
                {
                    if(hittedInteractable != currentSelectedInteractable)
                    {
                        currentSelectedInteractable = hittedInteractable;
                        previouslySelectedInteractable = currentSelectedInteractable;
                    }
                }
            }

            if(currentSelectedInteractable != null)
            {
                selectionResponse.OnSelected(currentSelectedInteractable);
            }
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.deltaTime);
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS      

        private void InitializeActions()
        {
            InputManager.Instance.InputData.RegisterLookAction(

                () => 
                {
                    /*Debug.Log("Look -> Started");*/
                },
                () => 
                {
                    /*Debug.Log("Look -> Performed");*/
                  

                },
                () => { /*Debug.Log("Look -> Canceled");*/}

                );

            InputManager.Instance.InputData.RegisterMovementAction(

                () => { /*Debug.Log("Movenent -> Started");*/ },
                () =>
                {
                    /*Debug.Log("Movenent -> Performed");*/
                    
                },
                () => { /*Debug.Log("Movenent -> Canceled");*/ }

                );

            InputManager.Instance.InputData.RegisterJumpAction(
            () => 
            {
                rb.AddForce(rb.transform.up * jumpMultiplier, ForceMode.Impulse);
            });

            InputManager.Instance.InputData.RegisterRunAction(
            () =>
            {
                movementSpeed = runSpeed;
            },

            null,

            () => 
            {
                movementSpeed = walkSpeed;
            });
        }

        private void HandleLookRotation()
        {
            var mouseLookAxis = InputManager.Instance.InputData.Look_Action.ReadValue<Vector2>();

            transform.Rotate(Vector3.up * mouseLookAxis.x * sensitivity * Time.deltaTime);
            verticalLookRotation += mouseLookAxis.y * sensitivity * Time.deltaTime;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
            cameraRig.localEulerAngles = Vector3.left * verticalLookRotation;
        }

        private void HandleMovement()
        {
            var movementAxis = InputManager.Instance.InputData.Movement_Action.ReadValue<Vector2>();

            var moveDirection = new Vector3(movementAxis.x, 0, movementAxis.y);
            var targetMoveAmount = moveDirection * movementSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, smooth);
        }
            
        #endregion CUSTOM_FUNCTIONS
    }
}