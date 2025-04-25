using UnityEditor.SearchService;
using UnityEngine;

public class ThrowObjectController : MonoBehaviour
{
    public static ThrowObjectController Instance;

    public GameObject currentObject {  get; set; }
    [SerializeField] private Transform objectTransform;
    [SerializeField] private Transform parentAfterThrow;
    [SerializeField] private ObjectSelector objectSelector;

    private PlayerController PlayerController;
    private Rigidbody2D rb;
    private CircleCollider2D CircleCollider;

    public Bounds Bounds { get; private set; }
    private const float ExtraWidth = 0.03f;

    public bool canThrow { get; set; } = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PlayerController = GetComponent<PlayerController>();
        if (currentObject != null)
        {
            Destroy(currentObject);
        }
        SpawnObject(objectSelector.PickRandomObjectForThrow());
    }

    private void Update()
    {
        if (InputPlayer.IsThrowPressed && canThrow)
        {
            SpriteIndex index = currentObject.GetComponent<SpriteIndex>();
            Quaternion rot = currentObject.transform.rotation;

            GameObject go = Instantiate(ObjectSelector.instance.objects[index.index], currentObject.transform.position, rot);
            go.transform.SetParent(parentAfterThrow);

            Destroy(currentObject);

            canThrow = false;

        }
    }
    public void SpawnObject(GameObject objects)
    {
        if (currentObject != null)
        {
            Destroy(currentObject);
        }
        GameObject go = Instantiate(objects, objectTransform);
        currentObject = go;
        CircleCollider = currentObject.GetComponent<CircleCollider2D>();
        Bounds = CircleCollider.bounds;

        PlayerController.ChangeBoudary(ExtraWidth);
    }

    public void ChangeCurrentObject()
    {
        GameObject newObject = objectSelector.PickRandomObjectForThrow();
        SpawnObject(newObject);
    }
}
