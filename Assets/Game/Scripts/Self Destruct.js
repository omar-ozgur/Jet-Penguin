#pragma strict

function FixedUpdate()
{
	Wait();
}

function Wait()
{
	yield WaitForSeconds(1);
	Destroy(this.gameObject);
}