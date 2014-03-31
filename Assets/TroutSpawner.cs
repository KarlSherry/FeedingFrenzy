using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TroutSpawner : MonoBehaviour {

	public GameObject fish;

	public int numberOfFish = 10;

	List<GameObject> fishList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberOfFish; i++) 
		{
			GameObject fishClone = Instantiate(fish, transform.position, transform.rotation) as GameObject; 
			fishList.Add (fishClone);
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
