using System;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public event Action OnClicked;

    private void OnMouseUpAsButton()
    {
        OnClicked?.Invoke();
    }
}