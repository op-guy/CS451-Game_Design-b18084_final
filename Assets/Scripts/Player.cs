using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;
	public float strafeSpeed = 5f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public AudioSource[] audio_source;

	public string currentColor;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

	public Text score, highScore;
	private int scoreCount;
	private Random rndom;
	private bool gravityDisabled;
	private float lower_bound;

	void Start ()
	{
		SetRandomColor();
		rb = GetComponent<Rigidbody2D>();
		scoreCount = 0;
		highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString(); 
		gravityDisabled = true;
		lower_bound = -1f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) {
			if(gravityDisabled) {
				GetComponent<Rigidbody2D>().gravityScale = 3;
				gravityDisabled = false;
			}
			audio_source[0].Play();
			rb.velocity = Vector2.up * jumpForce;
		}
		if(transform.position.y < lower_bound) {
			GameOver();
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		lower_bound = col.gameObject.transform.position.y - 20f;
		// Debug.Log(lower_bound);

		if (col.tag == "ColorChanger")
		{
			scoreCount++;
			score.text = "Score: " + scoreCount.ToString();
			if(PlayerPrefs.GetInt("HighScore") < scoreCount) {
				PlayerPrefs.SetInt("HighScore", scoreCount);
				highScore.text = "High Score: " + scoreCount.ToString();
			}
			audio_source[1].Play();
			SetRandomColor();
			Destroy(col.gameObject);
			return;
		}

		if (col.tag != currentColor)
		{
			// Debug.Log("GAME OVER!");
			GameOver();
		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}

	void GameOver() {
		audio_source[2].Play();
		SceneManager.LoadScene(2);
	}
}
