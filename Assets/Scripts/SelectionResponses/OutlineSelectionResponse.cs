using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class OutlineSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        #region VARIABLES

        //private Outline outline;

        #endregion VARIABLES

        #region PROPERTIES

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            //outline = GetComponent<Outline>();
        }

        private void Start()
        {
            //outline.OutlineWidth = 0;
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        public void OnDeselected(Interactable interactable)
        {
            //outline.enabled = false;
            //outline.OutlineWidth = 0;
        }

        public void OnSelected(Interactable interactable)
        {
            //outline.enabled = enabled;
            //outline.OutlineWidth = 10;
        }

        #endregion CUSTOM_FUNCTIONS      
    }
}