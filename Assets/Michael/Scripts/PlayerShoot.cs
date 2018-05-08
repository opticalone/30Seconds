
using UnityEngine.Networking;
using UnityEngine;

[RequireComponent(typeof(WeaponManager))]
public class PlayerShoot : MonoBehaviour 
{
	
	private const string PLAYERTAG = "Player";



	[SerializeField]
	private Camera cam;

	[SerializeField]
	private LayerMask mask;

	private Rigidbody rb;

	private PLayerWeapon currentWeapon;

	private WeaponManager weaponManager;

	void Start()
	{
		if (cam == null) {
			Debug.Log("PLAYERSHOOT: no camera ref");
			this.enabled = false;
		}
		weaponManager = GetComponent<WeaponManager>();
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		currentWeapon = weaponManager.GetCurrentWeapon ();

		if (currentWeapon.fireRate <= 0f)
		{
			if (Input.GetButtonDown ("Fire1"))
			{
				Shoot ();
			}
		}
		else 
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				InvokeRepeating ("Shoot", 0f, 1f / currentWeapon.fireRate);
			} 
			else if (Input.GetButtonUp ("Fire1"))
			{
				CancelInvoke("Shoot");
			}
		}
		if(Input.GetButton("Space"))
			{
			Boom ();
			}

	}

	
	void OnShoot()
	{
		DoShootEffect();
	}


	void DoShootEffect()
	{
		weaponManager.GetCurrentGraphics().mFlash.Play();
	}

	void OnHit(Vector3 _pos, Vector3 _normal)
	{
		DoHitEffect (_pos, _normal);
	}

	void DoHitEffect(Vector3 _pos, Vector3 _normal)
	{
		
		GameObject _hitEffect = (GameObject)Instantiate (weaponManager.GetCurrentGraphics ().hitEffectPrefab, _pos, Quaternion.LookRotation (_normal));
		Destroy (_hitEffect, 6f);
	}


	void Boom()
	{
		rb.AddExplosionForce (5f, transform.position,25f);
	}

	void Shoot()
	{
		

		
		OnShoot ();
		RaycastHit _hit;
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, currentWeapon.range, mask))
		{
			

			//hit effect

		OnHit (_hit.point, _hit.normal);

			Debug.DrawRay (cam.transform.position,cam.transform.forward * 200, Color.green );
			Debug.Log ("we hit" + _hit.collider.name);
			//hit something
		}
	}


}
