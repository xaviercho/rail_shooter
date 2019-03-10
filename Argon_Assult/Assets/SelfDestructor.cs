using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy(gameObject, 5f);  // to do allow customization
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
