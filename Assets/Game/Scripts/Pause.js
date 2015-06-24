#pragma strict

var player : Transform;

function FixedUpdate()
{
	if(!Collide.pause)
	{
		transform.renderer.enabled = false;	
		if(transform.GetComponent(BoxCollider) != null)
		{
			player.transform.GetComponent(BoxCollider).enabled = true;
		}
	}
	if(Collide.pause)
	{
		transform.renderer.enabled = true;	
		if(transform.GetComponent(BoxCollider) != null)
		{
			player.transform.GetComponent(BoxCollider).enabled = false;
		}
	}
}