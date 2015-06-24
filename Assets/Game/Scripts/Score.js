static var score = 0;

function FixedUpdate()
{
	guiText.text = ""+score.ToString();
	guiText.fontSize = Screen.width/10;
}