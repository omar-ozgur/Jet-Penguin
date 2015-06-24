#pragma strict

var player : GameObject;

function Start()
{
	player = GameObject.FindGameObjectWithTag("Player");
}

function FixedUpdate()
{
	if(player.transform.position.y > transform.position.y + 5)
	{
		Destroy(this.gameObject);
	}
	if(transform.position.y > player.transform.position.y + 5.25)
	{
		transform.renderer.enabled = false;
	}
	if(transform.position.y < player.transform.position.y + 5.25)
	{
		transform.renderer.enabled = true;
	}
}