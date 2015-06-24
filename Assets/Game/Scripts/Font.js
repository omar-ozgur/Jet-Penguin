#pragma strict

function Start()
{
		guiText.fontSize = Screen.width/35;
}

function FixedUpdate()
{
	if(!Collide.pause)
	{
		guiText.enabled = false;
	}
	else
	{
		guiText.enabled = true;
	}
}