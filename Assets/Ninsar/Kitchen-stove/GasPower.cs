using UnityEngine;

public class GasPower : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem gas;

    [SerializeField]
    private ParticleSystem gasEmbers;

    [SerializeField]
    private float gasMultiplier = 1f;

    public void OnGasPowerChanged(float gasPower)
    {
        var mainModule = gas.main;
        mainModule.startSizeMultiplier = gasPower * gasMultiplier;
        var embersModule = gasEmbers.main;
        embersModule.startSizeMultiplier = gasPower * gasMultiplier/10;
    }
}