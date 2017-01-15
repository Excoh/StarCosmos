using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findcentroid : MonoBehaviour {

	public List<Transform> targets;

	public Vector3 FindCentroid ( List< Transform > targets ) {

		Vector3 centroid;
		Vector3 minPoint = targets[ 0 ].position;
		Vector3 maxPoint = targets[ 0 ].position;

		for ( int i = 1; i < targets.Count; i ++ ) {
			Vector3 pos = targets[ i ].position;
			if( pos.x < minPoint.x )
				minPoint.x = pos.x;
			if( pos.x > maxPoint.x )
				maxPoint.x = pos.x;
			if( pos.y < minPoint.y )
				minPoint.y = pos.y;
			if( pos.y > maxPoint.y )
				maxPoint.y = pos.y;
			if( pos.z < minPoint.z )
				minPoint.z = pos.z;
			if( pos.z > maxPoint.z )
				maxPoint.z = pos.z;
		}

		centroid = minPoint + 0.5f * ( maxPoint - minPoint );

		return centroid;

	}  

	// Use this for initialization
	void Start () {
		//print (FindCentroid(targets).x + "x " + FindCentroid(targets).y + "y " + FindCentroid(targets).z + "z");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
