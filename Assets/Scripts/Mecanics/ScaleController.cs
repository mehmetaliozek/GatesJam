using UnityEngine;
using DG.Tweening;

public class ScaleController : MonoBehaviour
{
    public bool isCharBig = false;

    [Header("Büyüme-Küçülme Ayarlarý")]
    public float growScale = 1.5f;
    public float shrinkScale = 0.75f; // Küçülme miktarý
    public float duration = 0.5f;

    [Header("Shake Efekti Ayarlarý")]
    public float shakeDuration = 0.3f;  // Sarsýlma süresi
    public float shakeStrength = 0.2f;  // Sarsýlma þiddeti
    public int shakeVibrato = 8;        // Sarsýlma titreþim miktarý
    public float shakeRandomness = 90f;

    [Header("Punch Efekti Ayarlarý")]
    public float punchScaleAmount = 0.1f; // Küçülme sonrasý titreþim þiddeti 
    public float punchDuration = 0.2f;
    public float punchVibrate = 5f;
    public float punchElasticity = 1f;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartScaling();
        }
    }

    void StartScaling()
    {
        if (!isCharBig)
        {
            transform.DOScale(growScale, duration).SetEase(Ease.InOutElastic).OnComplete(() =>
            {
                transform.DOShakeScale(shakeDuration, shakeStrength, shakeVibrato, shakeRandomness, true);
                isCharBig = true;
            });
        }
        else
        {
            transform.DOScale(shrinkScale, duration).SetEase(Ease.InBounce).OnComplete(() =>
            {
                transform.DOPunchScale(Vector3.one * punchScaleAmount, punchDuration, shakeVibrato, punchElasticity);
                isCharBig = false;
            });
        }
    }
}
