using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject theDoor;

    public void Restart()
    {
        theDoor.SetActive(true);
        gameObject.SetActive(true);
    }

    public void OpenDoor()
    {
        theDoor.SetActive(false);
        gameObject.SetActive(false);
    }
}
