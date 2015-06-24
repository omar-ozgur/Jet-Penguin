#pragma strict

static var dash = false;
static var right = true;
static var speed = 5.0;

private var pos : Vector3;
private var move = true;
private var left = false;
private var temp = 0.0;
private var target = 0.0;
private var startPoint;
private var startTime = 0.0;
//private var xpos = 0.0;
//private var first = true;
//private var xtime = 0.0;
var LeftBlock : GameObject;
var RightBlock : GameObject;

function Awake()
{
	Application.targetFrameRate = 60.0;
	pos = Camera.main.ScreenToWorldPoint(Vector3(Screen.width,Screen.height,0));
	var rand1 = Random.Range(-7.5, -4.5);
	var rand2 = Random.Range(-7.5, -4.5);
	var rand3 = Random.Range(-7.5, -4.5);
	
	Instantiate(LeftBlock, Vector3(rand1, 0, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand1 + 11.5, 0, 0), Quaternion.identity);
	
	
	Instantiate(LeftBlock, Vector3(rand2, 4, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand2 + 11.5, 4, 0), Quaternion.identity);
	

	Instantiate(LeftBlock, Vector3(rand3, 8, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand3 + 11.5, 8, 0), Quaternion.identity);
}

function FixedUpdate()
{
    
	if(move)
	{
		if(right && (transform.position.x + (0.7)) < pos.x)
		{
			transform.localScale.x = -1.5;
			//transform.Translate(Vector3.right * Time.smoothDeltaTime * speed);
			transform.rigidbody.velocity = new Vector3(Time.smoothDeltaTime * speed * 55, 0, 0);
//			if(first)
//			{
//				//first = false;
//				transform.position = Vector3.Lerp(Vector3(xpos, transform.position.y, 0), Vector3(pos.x, transform.position.y, 0), (Time.time - xtime) / (speed / 2));
//			}	
//			if(!first)
//			{
//				transform.position = Vector3.Lerp(Vector3(-pos.x, transform.position.y, 0), Vector3(pos.x, transform.position.y, 0), (Time.time - xtime) / speed);
//			}
		}
		if(right && (transform.position.x + (0.7)) >= pos.x)
		{
			right = false;
			left = true;
			//first = false;
			//xtime = Time.time;
		}
		if(left && (transform.position.x - (0.7)) > -pos.x)
		{
			transform.localScale.x = 1.5;
			transform.rigidbody.velocity = new Vector3(Time.smoothDeltaTime * speed * -55, 0, 0);
			//transform.position = Vector3.Lerp(Vector3(pos.x, transform.position.y, 0), Vector3(-pos.x, transform.position.y, 0), (Time.time - xtime) / speed);
		}
		if(left && (transform.position.x - (0.7)) <= -pos.x)
		{
			left = false;
			right = true;
			//xtime = Time.time;
		}
		
		if(dash && !Collide.pause)
		{
    		//transform.position = Vector3.Lerp(startPoint, Vector3(transform.position.x, target, 0), (Time.time - startTime) / 0.3);

			if(transform.position.y < target)
			{
				transform.Translate (Vector3.up * 14 * Time.smoothDeltaTime);
			}
			if(transform.position.y >= target)
			{
				transform.rigidbody.velocity = new Vector3(0, 0, 0);
				//xtime = Time.time;
				audio.Play();
				Score.score += 1;
				transform.position.y = target;
				if(speed < 12)
				{
					speed += 0.5;
				}
				dash = false;
				right = true;
			}
		}
	}
}

function OnMouseDown()
{
	if(transform.position.y == target || transform.position.y == -2.5)
	{
//		first = true;
//		xpos = transform.position.x;
		startPoint = transform.position;
    	startTime = Time.time;
		temp = transform.position.y;
		target = temp + 4;
		right = false;
		left = false;
		dash = true;
		transform.rigidbody.velocity = Vector3(0,0,0);
	//Debug.Log(pos.x);
	var rand = Random.Range(-7.5, -4.5);
	Instantiate(LeftBlock, Vector3(rand, temp + 14.5, 0), Quaternion.identity);
	Instantiate(RightBlock, Vector3(rand + 11.5, temp + 14.5, 0), Quaternion.identity);
	}
}