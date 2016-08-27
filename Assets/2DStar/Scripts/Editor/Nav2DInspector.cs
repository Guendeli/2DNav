using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Nav2D))]
public class Nav2DInspector : Editor {

	private Nav2D polyNav{
		get {return target as Nav2D;}
	}

	public override void OnInspectorGUI(){

		polyNav.generateOnUpdate = EditorGUILayout.Toggle("Regenerate On Change", polyNav.generateOnUpdate);
		polyNav.inflateRadius = EditorGUILayout.FloatField("Radius", polyNav.inflateRadius);

		GUI.backgroundColor = new Color(0.7f, 0.7f, 1);
		if (GUILayout.Button("Add New Polygon Obstacle")){

			Nav2DObstacle newPoly= new GameObject("NavObstacle").AddComponent(typeof(Nav2DObstacle)) as Nav2DObstacle;
			newPoly.transform.parent = polyNav.transform;
			newPoly.transform.localPosition = new Vector3(0, 0, -1);
		}

		GUI.backgroundColor = Color.white;

		foreach (Nav2DObstacle c in polyNav.navObstacles.ToArray()){

			EditorGUILayout.BeginVertical("box");
			EditorGUILayout.BeginHorizontal();

			if (GUILayout.Button("Select"))
				Selection.activeObject = c.gameObject;

			GUI.backgroundColor = new Color(1, 0.7f, 0.7f);
			if (GUILayout.Button("Remove"))
				DestroyImmediate(c.gameObject);
			GUI.backgroundColor = Color.white;

			EditorGUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();
		}

		EditorGUILayout.LabelField("Nodes Count", polyNav.nodesCount.ToString());

		if (GUI.changed)
			EditorUtility.SetDirty(polyNav);
	}
}
