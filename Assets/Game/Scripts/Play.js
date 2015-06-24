#pragma strict

var player : Transform;
var LeftBlock : GameObject;
var RightBlock : GameObject;
var blocks : GameObject[];

function OnMouseDown()
{
	Time.timeScale = 1;
	player.transform.position.x = 0;
	player.transform.position.y = -2.5;
	Ship.speed = 5.0;
	Score.score = 0;
	Ship.dash = false;
	Ship.right = true;
	
	blocks = GameObject.FindGameObjectsWithTag ("Wall");
 
    for(var i = 0 ; i < blocks.length ; i ++)
    {
    	Destroy(blocks[i]);
    }
	
	var rand1 = Random.Range(-7.5, -4.5);
	var rand2 = Random.Range(-7.5, -4.5);
	var rand3 = Random.Range(-7.5, -4.5);
	
	Instantiate(LeftBlock, Vector3(rand1, 0, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand1 + 11.5, 0, 0), Quaternion.identity);
	
	
	Instantiate(LeftBlock, Vector3(rand2, 4, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand2 + 11.5, 4, 0), Quaternion.identity);
	

	Instantiate(LeftBlock, Vector3(rand3, 8, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand3 + 11.5, 8, 0), Quaternion.identity);
	
	Collide.pause = false;
}