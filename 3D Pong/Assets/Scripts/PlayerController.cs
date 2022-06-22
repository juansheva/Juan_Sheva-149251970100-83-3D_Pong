using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerNumber;

    public Enum.Position position;

    public Enum.Direction direction;

    private GameplayManager gameplayManager;
    public GoalController goalController;

    public int point;
    public int pointForLose;
    public int speed;

    public KeyCode plusKey;
    public KeyCode minusKey;

    public bool isLose;
    private Rigidbody rig;

    private Vector3 normalScale;
    private int normalSpeed;

    private void Start()
    {
        gameplayManager = FindObjectOfType<GameplayManager>();
        normalSpeed = speed;
        normalScale = transform.localScale;
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isLose)
        {
            if (point >= pointForLose)
            {
                isLose = true;
            }
            if (direction == Enum.Direction.Horizontal)
            {
                MoveObject(GetInput(Vector3.right));
            }
            if (direction == Enum.Direction.Vertical)
            {
                MoveObject(GetInput(Vector3.forward));
            }
        }
        else
        {
            goalController.gameObject.GetComponent<Collider>().isTrigger = false;
            goalController.gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameplayManager.playerLose += 1;
            gameplayManager.CheckWin();
            this.gameObject.SetActive(false);
        }
    }

    private Vector3 GetInput(Vector3 _arah)
    {
        if (Input.GetKey(plusKey))
        {
            return _arah * speed;
        }
        else if (Input.GetKey(minusKey))
        {
            return -_arah * speed;
        }

        return Vector3.zero;
    }

    private void MoveObject(Vector3 movement)
    {
        rig.velocity = movement;
    }

    public void GetPoint(int _increment)
    {
        point += _increment;
    }
}