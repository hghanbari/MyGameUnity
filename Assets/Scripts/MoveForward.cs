using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
   
    // If the player fires a missile, it moves to move
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
