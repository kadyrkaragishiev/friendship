using UnityEngine;
using DG.Tweening;

public class GasPower : MonoBehaviour
{
    [SerializeField]
    private Material fireMaterial;

    [SerializeField]
    private GameObject gas;

    private float lastGasValue;

    public void OnGasPowerChanged(float gasPower)
    {
        ChangeGasPower(gasPower);
        AddGasAnimation(gasPower);
    }

    private void AddGasAnimation(float gasPower)
    {
        if (lastGasValue < 0.05f && gasPower > 0.05f)
        {
            DOTween.To(() => 15f,
                x => fireMaterial.SetFloat("_ViewOffset", x), 3f, 1f);
        }

        lastGasValue = gasPower;
    }

    private void ChangeGasPower(float gasPower)
    {
        if (gasPower < 0.05f)
        {
            gas.SetActive(false);
        }
        else if (gasPower > 0.05f)
        {
            gas.SetActive(true);
        }

        fireMaterial.SetColor("_Color", new Color(gasPower, gasPower, gasPower));
    }
}