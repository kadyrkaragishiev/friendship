using DG.Tweening;
using UnityEngine;

namespace Baulimbo.Kitchen_stove
{
    public class GasPower : MonoBehaviour
    {
        [SerializeField]
        private Renderer renderer;
    
        [SerializeField]
        private Vector2 rangeView = new Vector2(-1 , 1);

        private float lastGasValue;

        private MaterialPropertyBlock _propertyBlock;
        private Tween _viewOffset;
    
        private bool _isTurnOn;
    
        private void Awake()
        {
            _propertyBlock = new MaterialPropertyBlock();

            SetViewOffset(3f);
        }

        public void OnGasPowerChanged(float gasPower)
        {
            ChangeGasPower(gasPower);
            AddGasAnimation(gasPower);
        }

        private void AddGasAnimation(float gasPower)
        {
            const float turnPower = 0.05f;
        
            if (!_isTurnOn && lastGasValue < turnPower && gasPower > turnPower)
            {
                var view = _propertyBlock.GetFloat("_ViewOffset");
                _viewOffset?.Kill();
                _viewOffset = DOTween.To(() => view, SetViewOffset, rangeView.y, 1f);

                _isTurnOn = true;
            }
            else if (_isTurnOn && lastGasValue < turnPower)
            {
                var view = _propertyBlock.GetFloat("_ViewOffset");

                _viewOffset?.Kill();
                _viewOffset = DOTween.To(() => view, SetViewOffset, rangeView.x, 0.5f);
            
                _isTurnOn = false;
            }

            lastGasValue = gasPower;
        }

        private void SetViewOffset(float value)
        {
            renderer.GetPropertyBlock(_propertyBlock);
            _propertyBlock.SetFloat("_ViewOffset", value);
            renderer.SetPropertyBlock(_propertyBlock);
        }

        private void ChangeGasPower(float gasPower)
        {
            renderer.GetPropertyBlock(_propertyBlock);

            var power = Mathf.Pow(gasPower, 1 / Mathf.PI * 2);
        
            _propertyBlock.SetColor("_Color", new Color(1, 1, 1, power));
        
            renderer.SetPropertyBlock(_propertyBlock);
        }
    }
}