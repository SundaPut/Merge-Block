using JetBrains.Annotations;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private BoxCollider2D boundaries;
    [SerializeField] private Transform objectThrowTransform;

    private Bounds bounds;
    private float leftBounds;
    private float rightBounds;

    private float startingLeftBounds;
    private float startingRightBounds;

    private float offset;

    private void Awake()
    {
        bounds = boundaries.bounds;
        offset = transform.position.x - objectThrowTransform.position.x;
        leftBounds = bounds.min.x + offset;
        rightBounds = bounds.max.x + offset;

        startingLeftBounds = leftBounds;
        startingRightBounds = rightBounds;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position + new Vector3(InputPlayer.MoveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, leftBounds, rightBounds);

        transform.position = newPosition;
    }

    public void ChangeBoudary(float extraWidth)
    {
        leftBounds = startingLeftBounds;
        rightBounds = startingRightBounds;

        leftBounds += ThrowObjectController.Instance.Bounds.extents.x + extraWidth;
        rightBounds -= ThrowObjectController.Instance.Bounds.extents.x + extraWidth;
    }
}