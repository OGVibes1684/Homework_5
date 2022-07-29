using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string levelName;

    public void NextLevel()
    {
        SceneManager.LoadScene(levelName);
        //Use SceneManager to move to next Level
        //Make sure you connect it to Button
    }

}
