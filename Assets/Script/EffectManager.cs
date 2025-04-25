using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private Transform cup;
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeMagnitude = 0.1f;

    private GameObject currentObject;
    private ThrowObjectController ThrowObjectController;
    private ObjectSelector objectSelector;

    private void Awake()
    {
        ThrowObjectController = GetComponent<ThrowObjectController>();
    }
    public void ShakeCup()
    {
        StartCoroutine(Shake(cup, shakeDuration, shakeMagnitude));
    }

    private IEnumerator Shake(Transform cupTransform, float duration, float magnitude)
    {
        Vector3 originalPosition = cupTransform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            cupTransform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        cupTransform.localPosition = originalPosition;
    }

    public void ChangeObject()
    {
        if (currentObject != null)
        {
            Destroy(currentObject); // Hapus objek lama
        }

        ThrowObjectController.ChangeCurrentObject();
        objectSelector.PickNextObject();
    }
}