using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class PortalEngine : MonoBehaviour
    {
        #region VARIABLES

        public Transform PlayerCameraRig;
        public Transform Portal;
        public Transform OtherPortal;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
        }

        private void Start()
        {
        }

        private void LateUpdate()
        {
            var playerOffsetFromPortal = PlayerCameraRig.position - OtherPortal.position;
            transform.position = Portal.position + playerOffsetFromPortal;

            var angularDifferenceBetweenPortalRotations = Quaternion.Angle(Portal.rotation, OtherPortal.rotation);

            var portalRotationalFifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);

            var newCameraDirection = portalRotationalFifference * PlayerCameraRig.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }

        private void FixedUpdate()
        {
        }

        private void HandleLookRotation()
        {
        }

        private void HandleMovement()
        {
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS      

        private void InitializeActions()
        {

        }

        #endregion CUSTOM_FUNCTIONS
    }
}
