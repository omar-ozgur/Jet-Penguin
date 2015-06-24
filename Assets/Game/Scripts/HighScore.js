#pragma strict

function FixedUpdate()
{
	guiText.text = "Record: "+(PlayerPrefs.GetInt("HighScore")).ToString();
	guiText.fontSize = Screen.width/15;
}