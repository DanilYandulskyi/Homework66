using UnityEngine;

[RequireComponent(typeof(HingeJoint2D))]
public class Swing : MonoBehaviour
{
    private HingeJoint2D _hingeJoint;

    private void Awake()
    {
        _hingeJoint = GetComponent<HingeJoint2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _hingeJoint.useMotor = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _hingeJoint.useMotor = false;
            
        }
    }
}
