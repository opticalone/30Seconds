using UnityEngine;

public class _PlayerController : MonoBehaviour
{


    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float lookSensitivity = 2f;

    //component cache
    private _PlayerMotor motor;
    private ConfigurableJoint joint;
	private Rigidbody rb;


    void Start()
    {
        motor = GetComponent<_PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();
		rb = GetComponent<Rigidbody> ();

    }


    void Update()
    {
        //Calc movement
        float _xMove = Input.GetAxis("Horizontal");
        float _zMove = Input.GetAxis("Vertical");
        Vector3 _moveHoriz = transform.right * _xMove;
        Vector3 _moveVert = transform.forward * _zMove;

        //final movment vectors
        Vector3 _velocity = (_moveHoriz + _moveVert) * speed;





        //apply movement :)

        motor.Move(_velocity);

        //calculate rotation as 3D vector
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rot = new Vector3(0, _yRot, 0) * lookSensitivity;

        //aply rot
        motor.Rot(_rot);




        //calculate CAMERA rotation as 3D vector
        float _xRot = Input.GetAxisRaw("Mouse Y");

        float _camRotX = _xRot * lookSensitivity;

        //aply rot
        motor.camRot(-_camRotX);



    }


}
