namespace Sweet_And_Salty_Studios
{
    public interface ISelectionResponse
    {
        void OnDeselected(Interactable interactable);
        void OnSelected(Interactable interactable);
    }
}