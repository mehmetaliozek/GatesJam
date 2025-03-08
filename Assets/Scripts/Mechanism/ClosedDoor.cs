using DG.Tweening;
using UnityEngine;

public class ClosedDoor : MonoBehaviour, IActivator
{
    float deafultY;

    private void Start()
    {
        deafultY = transform.localPosition.y;
    }

    public void Enable()
    {
        transform.DOLocalMoveY(-5, 1);
    }

    public void Disable()
    {
        transform.DOLocalMoveY(deafultY, 1);
    }
}
