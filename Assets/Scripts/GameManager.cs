using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject _NextButton;
    private bool _ReadyForInput;
    private Player _Player;


    private void Start()
    { 
        _Player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5)
        {
            if (_ReadyForInput) //Makes movement discrete
            {
                _ReadyForInput = false;
                _Player.Movement(moveInput);
            }
        }
        else
        {
            _ReadyForInput = true;
        }
    }

}
