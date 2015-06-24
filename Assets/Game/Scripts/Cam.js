#pragma strict

var player : Transform;
var distance = 3.5;

function FixedUpdate()
{
	transform.position.y = player.transform.position.y + distance;
}