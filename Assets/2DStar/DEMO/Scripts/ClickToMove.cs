using UnityEngine;
using System.Collections.Generic;

//example
[RequireComponent(typeof(Nav2DAgent))]
public class ClickToMove : MonoBehaviour{
	
	private Nav2DAgent _agent;
	public Nav2DAgent agent{
		get
		{
			if (!_agent)
				_agent = GetComponent<Nav2DAgent>();
			return _agent;			
		}
	}

	void Update() {
		if (Input.GetMouseButton(0))
			agent.SetDestination( Camera.main.ScreenToWorldPoint(Input.mousePosition) );
	}
}