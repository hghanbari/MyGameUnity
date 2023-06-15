using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWhith;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWhith= GetComponent<BoxCollider>().size.x / 2;
    }

    // Repeat the backgrand
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWhith)
        {
            transform.position = startPos;
        }
    }
}
