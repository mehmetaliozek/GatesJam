using DG.Tweening;
using UnityEngine;

public class Platform : MonoBehaviour, IActivator
{
    float deafultY;

    private void Start()
    {
        deafultY = transform.localPosition.y;
    }

    public void Enable()
    {
        transform.DOLocalMoveY(-3.5f, 1);
    }

    public void Disable()
    {
        transform.DOLocalMoveY(deafultY, 1);
    }
}
