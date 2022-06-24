using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public int score;
    public int speed;
    private Rigidbody rig;
    public float minimumSpeed;
    public int positionIndex;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        BallLaunch();
    }

    private void Update()
    {
        if (rig.velocity.magnitude < minimumSpeed)
        {
            rig.velocity = rig.velocity.normalized * minimumSpeed;
        }
    }

    public void BallLaunch()
    {
        float arahX = Random.Range(0.7f, 1.3f);
        float arahZ = Random.Range(0.7f, 1.3f);
        switch (positionIndex)
        {
            case 0:
                rig.velocity = new Vector3(arahX, 0, -arahZ) * speed;
                break;

            case 1:
                rig.velocity = new Vector3(-arahX, 0, -arahZ) * speed;
                break;

            case 2:
                rig.velocity = new Vector3(arahX, 0, arahZ) * speed;
                break;

            case 3:
                rig.velocity = new Vector3(-arahX, 0, arahZ) * speed;
                break;
        }
        //Vector3 arah = new Vector3(arahX, 0, arahZ);
        //rig.velocity = arah * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            rig.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}