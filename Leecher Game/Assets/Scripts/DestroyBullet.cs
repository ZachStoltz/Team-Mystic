using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {
	
	public float lifeTime = 1.0f;
	void Awake(){
	
		Destroy(gameObject, lifeTime);
	}
}
