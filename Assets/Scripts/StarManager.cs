using UnityEngine;
using System.Collections;

public class StarManager : MonoBehaviour {

    public GameObject starPrefab; // The star to spawn
    public float maxDistance;
    public float force = 1f;

	// Use this for initialization
	void Start () { 
        for (int i = 0; i < 200; i++)
        {
            Instantiate(starPrefab, randomPos(-1, 1), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Spawning Stars");
            Instantiate(starPrefab, randomPos(-1, 1), Quaternion.identity);
        }
	}

    Vector3 randomPos(float min, float max)
    {
        return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
    }
}
