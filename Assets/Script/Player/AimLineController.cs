using UnityEngine;

public class AimLineController : MonoBehaviour
{
    [SerializeField] private Transform ObjectThrowTransform;
    [SerializeField] private Transform bottomTransform;

    private LineRenderer lineRenderer;

    private float topPos;
    private float bottomPos;
    private float _x;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        _x = ObjectThrowTransform.position.x;
        topPos = ObjectThrowTransform.position.y;
        bottomPos = bottomTransform.position.y;

        lineRenderer.SetPosition(0, new Vector3(_x, topPos));
        lineRenderer.SetPosition(1, new Vector3(_x, bottomPos));
    }

    private void OnValidate()
    {
        lineRenderer = GetComponent<LineRenderer>();

        _x = ObjectThrowTransform.position.x;
        topPos = ObjectThrowTransform.position.y;
        bottomPos = bottomTransform.position.y;

        lineRenderer.SetPosition(0, new Vector3(_x, topPos));
        lineRenderer.SetPosition(1, new Vector3(_x, bottomPos));
    }
}

