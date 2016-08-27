using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//example. moving between some points at random
[RequireComponent(typeof(Nav2DAgent))]
public class MoveBetween : MonoBehaviour{

	public List<Vector2> WPoints = new List<Vector2>();

	private Nav2DAgent _agent;
	public Nav2DAgent agent{
		get
		{
			if (!_agent)
				_agent = GetComponent<Nav2DAgent>();
			return _agent;			
		}
	}

	void OnEnable(){
		agent.OnDestinationReached += MoveRandom;
		agent.OnDestinationInvalid += MoveRandom;
	}

	void OnDisable(){
		agent.OnDestinationReached -= MoveRandom;
		agent.OnDestinationInvalid -= MoveRandom;
	}


	IEnumerator Start(){
		yield return new WaitForSeconds(1);
		if (WPoints.Count > 0)
			MoveRandom();
	}

	void MoveRandom(){
		agent.SetDestination(WPoints[Random.Range(0, WPoints.Count)]);		
	}

	void OnDrawGizmosSelected(){
		for ( int i = 0; i < WPoints.Count; i++)
			Gizmos.DrawSphere(WPoints[i], 0.05f);			
	}
}
