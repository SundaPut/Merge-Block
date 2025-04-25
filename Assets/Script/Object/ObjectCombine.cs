using UnityEditor.Tilemaps;
using UnityEngine;

public class ObjectCombine : MonoBehaviour
{
    private int layerIndex;

    private ObjectInfo _info;

    private void Awake()
    {
        _info = GetComponent<ObjectInfo>();
        layerIndex = gameObject.layer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == layerIndex)
        {
            ObjectInfo info =collision.gameObject.GetComponent<ObjectInfo>();
            if (info != null)
            {
                if (info.objectIndex == _info.objectIndex)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID= collision.gameObject.GetInstanceID();

                    if (thisID > otherID)
                    {
                        GameManager.instance.IncreaseScore(_info.pointWhenAnnihilate);

                        if (_info.objectIndex == ObjectSelector.instance.objects.Length - 1)
                        {
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                        else
                        {
                            Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                            GameObject go = Instantiate(SpawnCombinedObject(_info.objectIndex), GameManager.instance.transform);

                            ColliderInformer informer = go.GetComponent<ColliderInformer>();
                            if (informer != null)
                            {
                                informer.wasCombined = true;
                            }

                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }
    private GameObject SpawnCombinedObject(int index)
    {
        GameObject go = ObjectSelector.instance.objects[index + 1];
        return go;
    }
}
