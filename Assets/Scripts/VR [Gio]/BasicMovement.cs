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
    [SerializeField] float speed = 1;
    private float zoomActual;
    Rigidbody m_Rigidbody;

    void Start() {
        m_Rigidbody = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        esfera = GameObject.Find("Sphere");
        zoomActual=2;
    }

    
    void Update() {
        m_Rigidbody.MovePosition( transform.forward * speed * Time.deltaTime );
        //positionActual =  m_Rigidbody.position;

        Debug.Log(m_Rigidbody.position);
        Debug.Log(positionActual);
        Debug.Log( Time.deltaTime);

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
/**
    private void Zoom1(){
		esfera.transform.position = new Vector3(positionActual.x,positionActual.y+ (1*devolverAltura(positionActual.z)),positionActual.z+1);
        Debug.Log(esfera.transform.position);
        zoomActual=1;
	}

	private void Zoom2(){
        esfera.transform.position = new Vector3(positionActual.x,positionActual.y+ (1*devolverAltura(positionActual.z)),positionActual.z+1);
        Debug.Log(esfera.transform.position);
        zoomActual=3;
	}

	private void Zoom3(){
        m_Rigidbody.position = positionActual * 10;
        Debug.Log(m_Rigidbody.position);
        zoomActual=10;

	}
    private void regresarZoom(){
         esfera.transform.position = new Vector3(positionActual.x,positionActual.y- (zoomActual*devolverAltura(positionActual.z)),positionActual.z-zoomActual);
    }
**/
    private void Zoom(int zoom){
        regresarZoom();
		m_Rigidbody.MovePosition( transform.forward * zoom );
        zoomActual=zoom;
	}

    private void regresarZoom(){
        m_Rigidbody.MovePosition( transform.forward / zoomActual );
    }
/**
    private float devolverAltura(float z){
        float y= z*Mathf.Tan(rotationY);
        return y;
    }
    
**/
}
