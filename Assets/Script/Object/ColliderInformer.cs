using UnityEngine;

public class ColliderInformer : MonoBehaviour
{
    public bool wasCombined { get; set; }

    private bool hasCollide;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasCollide && !wasCombined)
        {
            hasCollide = true;
            ThrowObjectController.Instance.canThrow = true;
            ThrowObjectController.Instance.SpawnObject(ObjectSelector.instance.NextObject);
            ObjectSelector.instance.PickNextObject();
            Destroy(this);
        }
    }
}
