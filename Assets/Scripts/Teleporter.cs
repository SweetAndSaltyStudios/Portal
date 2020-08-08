using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Teleporter : MonoBehaviour
    {
        #region VARIABLES

        public Transform Player;
        public Transform Receiver;

        private bool isOverlapping;

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

        private void Update()
        {
            if(isOverlapping == false)
            {
                return;
            }

            var directionFromPortalToPlayer = Player.position - transform.position;
            var dotProduct = Vector3.Dot(transform.up, directionFromPortalToPlayer);

            if(dotProduct < 0)
            {
                var rotationDifferene = Quaternion.Angle(transform.rotation, Receiver.rotation);

                rotationDifferene += 180;
                Player.Rotate(Vector3.up, rotationDifferene);

                var positionOffset = Quaternion.Euler(0, rotationDifferene, 0) * directionFromPortalToPlayer;
                Player.position = Receiver.position + positionOffset;

                isOverlapping = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                isOverlapping = true;

                print(gameObject.name);
           
            }
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS      

        #endregion CUSTOM_FUNCTIONS
    }
}