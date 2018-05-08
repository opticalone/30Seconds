using UnityEngine;

public class _PlayerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    private Vector3 vel = Vector3.zero;     //velocity
    private Vector3 rotation = Vector3.zero;//rotation

    //camera rotations
    private float camRotaionX = 0f;
    private float currentCamRotX = 0f;

    private Rigidbody rb;                   //init rb
    [SerializeField]
    private float camRotLimit = 89.99f;     //cam rotation limit


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //gets movement vector
    public void Move(Vector3 _velocity)
    {
        vel = _velocity;
    }

    //gets Rotation vector
    public void Rot(Vector3 _rotato)
    {
        rotation = _rotato;
    }


 
    public void camRot(float _camRotationX)
    {
        camRotaionX = _camRotationX;
    }



    //run every physics itteraation
    void FixedUpdate()
    {

        preformRotato();
    }
    void LateUpdate()
    {
        preformMovement();
    }

    //preform movement based on velocity

    void preformMovement()
    {
        if (vel != Vector3.zero)
        {

            rb.MovePosition(rb.position + vel * Time.fixedDeltaTime);

        }

      
    }

    void preformRotato()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            //rotational calc with clamps
            currentCamRotX += camRotaionX;
            currentCamRotX = Mathf.Clamp(currentCamRotX, -camRotLimit, camRotLimit);

            cam.transform.localEulerAngles = new Vector3(currentCamRotX, 0f, 0f);
        }


    }

}
