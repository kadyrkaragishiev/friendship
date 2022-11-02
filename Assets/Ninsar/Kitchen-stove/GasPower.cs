using UnityEngine;

public class GasPower : MonoBehaviour
{
    [SerializeField]
    private Material fireMaterial;

    [SerializeField]
    private GameObject gas;

    public void OnGasPowerChanged(float gasPower)
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