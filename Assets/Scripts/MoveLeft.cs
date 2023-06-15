using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10;
    private GameManager gameManagerScript;
    private float leftBound = -5;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = gameManagerScript.speed;

        if (gameObject.tag == "Powerup")
        {
            speed += 4;
        }
    }

    // Speed the enemy en move the left
    void Update()
    {

        if (gameManagerScript.isGameActive == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
