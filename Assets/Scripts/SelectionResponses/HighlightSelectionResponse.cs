using UnityEngine;

namespace Sweet_And_Salty_Studios
{
    public class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
    {
#pragma warning disable 649
        private Material highlightMaterial;
#pragma warning restore 649
        private Material defaultMaterial;

        public void OnSelected(Interactable interactable)
        {
            if(interactable != null)
            {
                defaultMaterial = interactable.Renderer.material;

                interactable.Renderer.material = highlightMaterial;
            }
        }

        public void OnDeselected(Interactable interactable)
        {
            if(interactable != null)
            {
                interactable.Renderer.material = defaultMaterial;
            }
        }
    }
}