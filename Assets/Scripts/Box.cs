using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box : MonoBehaviour
{
    [SerializeField] private SceneController manager;
    public bool _OnGoal;
    public bool Movement(Vector2 direction)
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }

        transform.Translate(direction);
        TestForOnGoal();
        return true;
    }
    bool BoxBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newpos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newpos.x && wall.transform.position.y == newpos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newpos.x && box.transform.position.y == newpos.y)
            {
                return true;
            }
        }
        return false;
    }
    public void TestForOnGoal()
    {
        GameObject[] goals = GameObject.FindGameObjectsWithTag("Goal");
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        if (boxes[0].transform.position == goals[0].transform.position)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            _OnGoal = true;
            manager.NewLevel(false);
            return;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        _OnGoal = false;
    }

}
