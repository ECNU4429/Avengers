using UnityEngine;
using System.Collections;

public class backgroundFloowCam : MonoBehaviour {

	public Transform theBackground;		
	private Transform cam;						// Shorter reference to the main camera's transform.
	private Vector3 previousCamPos;				// The postion of the camera in the previous frame.
	public float smoothing;						// How smooth the parallax effect should be.

	void Awake ()
	{
		// Setting up the reference shortcut.
		cam = Camera.main.transform;
	}


	void Start ()
	{
		// The 'previous frame' had the current frame's camera position.
		previousCamPos = cam.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		previousCamPos.z=theBackground.position.z;
		theBackground.position = Vector3.Lerp(theBackground.position, previousCamPos, smoothing * Time.deltaTime);
		previousCamPos = cam.position;
	}
}
