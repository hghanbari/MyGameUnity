using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    
    private GameManager gameManagerScripts;
    void Start()
    {
        gameManagerScripts = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gameManagerScripts.playHitSound();
        gameManagerScripts.playEnemyExplosion(gameObject.transform.position);
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameManagerScripts.UpdatScore(1);
    }
}
