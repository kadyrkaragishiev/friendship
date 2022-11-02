using System;
using Lean.Touch;
using UnityEngine;
using UnityEngine.Events;

public class GasPowerSwitcher : MonoBehaviour
{
    public LeanSelectableDial Dial;
    public PowerChangedEvent OnPowerChanged;

    [SerializeField]
    private AudioSource baseSound;

    [SerializeField]
    private AudioSource enablingSound;

    [SerializeField]
    private GasPower _gasPower;

    [SerializeField]
    private float fpsMultiplier = 1;
    private float _lastValue;

    private void Start()
    {
        Dial.OnAngleChanged.AddListener(OnAngleChanged);
        OnPowerChanged.AddListener(ChangeAudioVolume);
        OnPowerChanged.AddListener(_gasPower.OnGasPowerChanged);
        OnPowerChanged.AddListener(EnablingGasPowerSoundStarter);
    }

    private void ChangeAudioVolume(float volume) => baseSound.volume = volume;

    private void OnAngleChanged(float angle) => OnPowerChanged?.Invoke(GetAngleProgress(angle));

    private float GetAngleProgress(float angle) => Mathf.InverseLerp(Dial.ClampMax, Dial.ClampMin, angle);

    private void EnablingGasPowerSoundStarter(float power)
    {
        Debug.Log(_lastValue < 0.05f && power > 0.05f);
        if (_lastValue < 0.05f && power > 0.05f)
            enablingSound.Play();
        _lastValue = power;
    }

    private void FPSChanger(float power)
    {
        //Heat CPU by 10% if power is 100%
        Application.targetFrameRate = (int)(60 + 60 * power * fpsMultiplier);
    }
}

[Serializable]
public class PowerChangedEvent : UnityEvent<float>
{
}