

var lookForTarget : Transform;
var rotationDamper = 6.0;
var flameBulletPrefab : Transform;
var savedTime = 0;

function Update () {

	if(lookForTarget){
	
		var rotate = Quaternion.LookRotation(lookForTarget.position - transform.position);
		
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * rotationDamper);
		
		var seconds : int = Time.time;
		var oddOrEven = (seconds % 2);
		if(oddOrEven){
		Shoot(seconds);
		}
	}
	

}
	function Shoot (seconds){
	
		if(seconds!=savedTime){
		var bullet = Instantiate(flameBulletPrefab, transform.Find("spawnPoint").transform.position,Quaternion.identity);
		bullet.rigidbody.AddForce(transform.forward * 1000);
	
		savedTime = seconds;
		}
	}