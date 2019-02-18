using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private void Start()
    {
       if (PlayerPrefs.GetInt("Setup") == 0)
        {
            PlayerPrefs.SetInt("Setup", 1);
            PlayerPrefs.SetString("Scene", "Level1");
        }
       
       //SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
        
    }
    
     public bool Movement(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < .5) //Make sure one coord is always 0
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize(); //Either x or y can move
        if (Blocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            return true;

        }
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newpos.x && wall.transform.position.y  == newpos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newpos.x && box.transform.position.y == newpos.y)
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Movement(direction))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Setup", 0);
    }  
}
