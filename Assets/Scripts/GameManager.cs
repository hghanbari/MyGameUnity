using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float speed = 10;
    public bool isGameActive = false;

    public AudioClip fireSound;
    public AudioClip crashSound;
    public AudioClip hitSound;

    public ParticleSystem explosionParticle;
    public ParticleSystem enemyExplosionParticle;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI playeGame;
    public TextMeshProUGUI PlayerController;
    public TextMeshProUGUI rocktActive;

    public Button restartButton;
    public Button eseyButton;
    public Button madiumButton;
    public Button hardButton;

    private AudioSource playerAudio;
    private SpawnManager spawnManager;
    private int score;
  
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // If the missile hits the enemy, it gets points
    public void UpdatScore(int scoreToAad)
    {
        score += scoreToAad;
        scoreText.text = "Score: " + score;
    }
    // If the player hits the enemy
    public void GameOver(Vector3 poisition)
    {
        isGameActive = false;
        selfExplosion(poisition);
        playCrashSound();
        restartButton.gameObject.SetActive(true);
        playeGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }
    // Reset the all the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start the game 
    public void StartGame(float s)
    {
        speed = s;
        isGameActive = true;
        score = 0;
        UpdatScore(0);
        spawnManager.SpawnPlayer();
        spawnManager.StartSpawning(speed);
        restartButton.gameObject.SetActive(false);
        eseyButton.gameObject.SetActive(false);
        madiumButton.gameObject.SetActive(false);
        hardButton.gameObject.SetActive(false);
        playeGame.gameObject.SetActive(false);
        PlayerController.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }
    // Visul effect
    public void selfExplosion(Vector3 poisition)
    {
        explosionParticle.transform.position = poisition;
        explosionParticle.Play();

    }
    public void playEnemyExplosion(Vector3 poisition)
    {
        enemyExplosionParticle.transform.position = poisition;
        enemyExplosionParticle.Play();
    }
    // Suond effect
    public void playFireSound()
    {
        playerAudio.PlayOneShot(fireSound, 1.0f);
    }
    public void playCrashSound()
    {
        playerAudio.PlayOneShot(crashSound, 1.0f);
    }
    public void playHitSound()
    {
        playerAudio.PlayOneShot(hitSound, 1.0f);
    }
}
