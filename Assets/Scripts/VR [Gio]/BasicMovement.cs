using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {
    new Camera camera;
    public float climbSpeed = 5;
    private float rotationX = 0.0f;
	private float rotationY = 0.0f;
	private float maxRotationUpY = 45.0f;
	private float minRotationDowmY = 15.0f;
    private Vector3 positionActual;
    private GameObject esfera;
    private float zoomActual;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        esfera = GameObject.Find("Sphere");
    }

    
    void Update() {
        //Vector3 velocity = transform.right *1;
        //transform.position += velocity * Time.deltaTime;
        positionActual=transform.position;
        if (Input.GetAxis("Vertical") == 1){InclinarArriba();}
		if (Input.GetAxis("Vertical") == -1) {InclinarAbajo();}

        if (Input.GetButtonDown("Zoom1")){
            Zoom(1);
        }
		if (Input.GetButtonDown("Zoom2")){
            Zoom(5);
        }
		if (Input.GetButtonDown("Zoom3")){
            Zoom(10);
        }
    }

        private void InclinarArriba(){
			if (rotationY > -maxRotationUpY) {
                var nuevaRotacion = (-climbSpeed) * Time.deltaTime;
				esfera.transform.Rotate(nuevaRotacion, 0, 0, Space.Self);
				rotationY += nuevaRotacion;
				//Debug.Log(rotationY);
			}
		}

		private void InclinarAbajo(){
			if (rotationY < minRotationDowmY) {
				var nuevaRotacion = climbSpeed * Time.deltaTime;
				esfera.transform.Rotate(nuevaRotacion, 0, 0, Space.Self);
				rotationY += nuevaRotacion;
				//Debug.Log(rotationY);
			}
		}

    private void Zoom(int zoom){
        regresarZoom();
        if(zoom==1){
            esfera.transform.position=positionActual;
        }else{
            esfera.transform.position=positionActual+(camera.transform.forward*zoom)+ new Vector3(0,0.01f*rotationY,0);
        }
		zoomActual=zoom;
	}

    private void regresarZoom(){
        if(zoomActual==1){
            esfera.transform.position=positionActual;
        }else{
            esfera.transform.position=positionActual- (camera.transform.forward*zoomActual)-new Vector3(0,0.01f*rotationY,0);
        }
    }
}
