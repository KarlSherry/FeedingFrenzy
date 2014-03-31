using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TroutSpawner : MonoBehaviour {

	public GameObject fish;

	public int numberOfFish = 0;

	List<GameObject> fishList = new List<GameObject>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < numberOfFish; i++) 
		{
			fishList.Add (fish);
		}
	}
}
