#pragma strict

static var pause = false;
var explosion : GameObject;
var player : Transform;

function OnTriggerEnter2D (hit : Collider2D)
{
	if(hit.gameObject.tag == "Wall")
	{
		player.rigidbody.velocity = new Vector3(0, 0, 0);
		player.transform.position.y = hit.gameObject.transform.position.y - 1;
		Instantiate(explosion, transform.position, Quaternion.identity);
		audio.Play();
		if(Score.score > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", Score.score);
		}
		pause = true;
	}
}