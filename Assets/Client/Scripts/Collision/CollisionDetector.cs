using UnityEngine;

public class CollisionDetector : EcsComponent 
{
    public Transform Box;
    public LayerMask IgnoreMask;

    private void OnCollisionStay(Collision collision)
    {
        
    }
}