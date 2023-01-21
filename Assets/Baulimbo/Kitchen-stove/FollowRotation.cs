using UnityEngine;

namespace Baulimbo.Kitchen_stove
{
    public class FollowRotation : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        private void Update() => transform.rotation = target.rotation;
    }
}
