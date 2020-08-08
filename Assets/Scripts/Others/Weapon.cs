using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Weapon : MonoBehaviour
    {
        #region VARIABLES

        [Space]
        [Header("Projectiles")]
        public Projectile ProjectilePrefab;
        public Transform ProjectileSpawnPoint;

        private Projectile currentProjectile;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void StartFire()
        {
            if(ProjectilePrefab == null)
            {
                return;
            }

            currentProjectile = Instantiate(ProjectilePrefab, ProjectileSpawnPoint.position, Quaternion.identity, transform);
        }

        public void ContinuousFire()
        {
            Debug.LogError("!!!");
        }

        public void CancelFire()
        {
            if(currentProjectile == null)
            {
                return;
            }

            Destroy(currentProjectile.gameObject);
        }

        #endregion CUSTOM_FUNCTIONS
    }
}

