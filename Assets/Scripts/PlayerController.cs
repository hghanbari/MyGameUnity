using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRb;
    public float firammo = 2;
    public GameObject projectilePrefab;
    public float verticalInput;
    public float horizontalInput;
    public float speed = 10.0f;
    private float highBounds = 18.0f;
    private float lowBounds = 2.0f;
    public bool haspowerup;
    public GameObject[] powerupIndicator;
    private GameManager gameManagerScripts;
    public ParticleSystem fireParticle;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScripts = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        // player move up en down
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        // Keep the player in bounds
        if (transform.position.y > highBounds)
        {

            transform.position = new Vector3(transform.position.x, highBounds, transform.position.z);
        }
        if (transform.position.y < lowBounds)
        {

            transform.position = new Vector3(transform.position.x, lowBounds, transform.position.z);
        }

        // player move for and back
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);

        // Keep the player in bounds
        if (transform.position.x > highBounds)
        {

            transform.position = new Vector3(highBounds, transform.position.y, transform.position.z);
        }
        if (transform.position.x < lowBounds)
        {

            transform.position = new Vector3(lowBounds, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space) && haspowerup)
        {
            gameManagerScripts.playFireSound();
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        if(haspowerup)gameManagerScripts.rocktActive.gameObject.SetActive(true);
        else{gameManagerScripts.rocktActive.gameObject.SetActive(false);}
            
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            haspowerup = true;
            powerupIndicator[0].gameObject.SetActive(true);
            powerupIndicator[1].gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        };
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        haspowerup = false;
        powerupIndicator[0].gameObject.SetActive(false);
        powerupIndicator[1].gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            fireParticle.Stop();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gameManagerScripts.GameOver(gameObject.transform.position);
        }
    }
}
