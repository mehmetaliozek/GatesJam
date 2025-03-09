using DG.Tweening;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IActivator
{
    public float targetY = -5;
    float deafultY;

    private void Start()
    {
        deafultY = transform.localPosition.y;
    }

    public void Enable()
    {
        transform.DOLocalMoveY(targetY, 1);
    }

    public void Disable()
    {
        transform.DOLocalMoveY(deafultY, 1);
    }
}
