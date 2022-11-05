using UnityEngine;
using DG.Tweening;
using Lean.Touch;
using UnityEngine.UI;

public class UIDisabler : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup group;

    [SerializeField]
    private Image bgImage;

    [SerializeField]
    private LeanSelectableDial rotateTransform;

    void Start()
    {
        group.DOFade(1, 2f).OnComplete(() =>
        {
            group.DOFade(1, 2f).OnComplete(() =>
            {
                bgImage.DOFade(0, 0.5f);
                group.DOFade(0, 0.5f).OnComplete(() =>
                {
                    group.gameObject.SetActive(false);
                    bgImage.gameObject.SetActive(false);
                    DOTween.To(() => rotateTransform.Tilt, x => rotateTransform.Tilt = x,
                        new Vector3(0, 0, -30f), 0.5f).OnComplete(() =>
                    {
                        DOTween.To(() => rotateTransform.Tilt, x => rotateTransform.Tilt = x, 
                            new Vector3(0, 0, 0), 0.5f);
                    });
                });
            });
        });
    }
}