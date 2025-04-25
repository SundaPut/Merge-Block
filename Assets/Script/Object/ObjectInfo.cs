using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public int objectIndex = 0;
    public int pointWhenAnnihilate = 1;
    public float objectMass = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.mass = objectMass;
    }
}
