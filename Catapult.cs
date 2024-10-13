using UnityEngine;

[RequireComponent(typeof(SpringJoint2D))]
public class Catapult : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _projectile;
    [SerializeField] private float _shootingSpeed;
    [SerializeField] private float _shootingForce = 300;

    private SpringJoint2D _springJoint2D;
    private Quaternion _initialRotation;

    private void Awake()
    {
        _initialRotation = transform.rotation;
        _springJoint2D = GetComponent<SpringJoint2D>();
    }

    private void Update()
    {
        float targetAngle = -45;

        if (Input.GetKey(KeyCode.Space))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,
            new Quaternion(transform.rotation.x, transform.rotation.y, targetAngle, 0), _shootingSpeed * Time.fixedDeltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Shoot();
            

            transform.rotation = Quaternion.Lerp(transform.rotation,
            _initialRotation, _shootingSpeed * Time.fixedDeltaTime);
        }
    }

    private void Shoot()
    {
        _projectile.AddForce((_springJoint2D.anchor + Vector2.one).normalized * _shootingForce);
    }
}
