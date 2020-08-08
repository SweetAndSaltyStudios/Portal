using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class SetupRenderTexture : MonoBehaviour
    {
        #region VARIABLES

        public Camera Camera_B;

        public Material Camera_B_Material;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            if(Camera_B.targetTexture != null)
            {
                Camera_B.targetTexture.Release();
            }

            Camera_B.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            Camera_B_Material.mainTexture = Camera_B.targetTexture;
        }

        private void Start()
        {

        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS      

        #endregion CUSTOM_FUNCTIONS
    }
}