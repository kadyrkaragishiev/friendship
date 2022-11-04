using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private void Update() => transform.rotation = target.rotation;
}
