﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonDrawer : MonoBehaviour {

	public List<Dot> userTops;

	public GameObject topPrefab;
	public GameObject lineRenderPrefab;
	public GameObject importantPrefab;

	protected GameObject scenePolygon;

	// Use this for initialization
	void Start () {
		scenePolygon = new GameObject ();
		scenePolygon.name = this.name + " polygon";
		Polygon pol = new Polygon (this, userTops);

		if (!pol.HaveKernel ()) {
			Debug.Log ("Nie ma jądra");
		} else {
			pol.calculateCircuit ();
			pol.calculateArea ();
		}
	}

	public GameObject DrawTop(float x, float y){
		return Instantiate (topPrefab, new Vector3 (x, y, 0f), Quaternion.identity, scenePolygon.transform) as GameObject;
	}

	public void DrawImportantObject(float x, float y){
		Instantiate (importantPrefab, new Vector3 (x, y, 0f), Quaternion.identity, scenePolygon.transform);
	}

	public void DrawLine(Vector3 one, Vector3 two, Color color, float width){
		GameObject renderObj = Instantiate (lineRenderPrefab, scenePolygon.transform) as GameObject;
		LineRenderer renderer = renderObj.GetComponent<LineRenderer> ();
		renderer.SetPosition (0, one);
		renderer.SetPosition (1, two);
		renderer.startColor = color;
		renderer.endColor = color;

		renderer.startWidth = width;
		renderer.endWidth = width;
	}

	public void Clear(){
		Destroy (scenePolygon);
		Destroy (this.gameObject);
	}
}
