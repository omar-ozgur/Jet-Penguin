#pragma strict

var normal : Sprite;
var crown : Sprite;

function FixedUpdate()
{
	if(PlayerPrefs.GetInt("HighScore") < 15)
	{
		transform.GetComponent(SpriteRenderer).sprite = normal;
	}
	if(PlayerPrefs.GetInt("HighScore") >= 15)
	{
		transform.GetComponent(SpriteRenderer).sprite = crown;
	}
}