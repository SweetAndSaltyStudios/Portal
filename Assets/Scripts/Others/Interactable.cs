using System;
using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class Interactable : MonoBehaviour
    {
        #region VARIABLES

        #endregion VARIABLES

        #region PROPERTIES

        public Renderer Renderer
        {
            get;
            private set;
        }

        #endregion PROPERTIES

        #region UNITY_FUNCTIONS

        private void Awake()
        {
            Renderer = GetComponentInChildren<Renderer>();
        }

        #endregion UNITY_FUNCTIONS

        #region CUSTOM_FUNCTIONS

        #endregion CUSTOM_FUNCTIONS
    }
}

