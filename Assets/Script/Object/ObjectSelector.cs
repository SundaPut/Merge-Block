using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelector : MonoBehaviour
{
    public static ObjectSelector instance;

    public GameObject[] objects;
    public GameObject[] noPhysicsObject;
    public int highestStartingIndex = 3;

    [SerializeField] private Image nextObjectImage;
    [SerializeField] private Sprite[] objectSprites;

    public GameObject NextObject { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PickNextObject();
    }

    public GameObject PickRandomObjectForThrow()
    {
        int randomIndex =Random.Range(0, highestStartingIndex + 1);

        if (randomIndex < noPhysicsObject.Length)
        {
            GameObject randomObject = noPhysicsObject[randomIndex];
            return randomObject;
        }

        return null;
    }

    public void PickNextObject()
    {
        int randomIndex = Random.Range(0, highestStartingIndex + 1);

        if (randomIndex < objects.Length)
        {
            GameObject nextObject = noPhysicsObject[randomIndex];
            NextObject = nextObject;

            nextObjectImage.sprite = objectSprites[randomIndex];
        }
    }
}
