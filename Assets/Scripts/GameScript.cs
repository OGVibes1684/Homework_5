using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    //=========== GUI Elements 
    public TextMeshProUGUI score;   //Tells us the score of the player 
    public TextMeshProUGUI lives;   //Tells us how many lives the player has 

    private int scoreCounter = 0;   //Keeps Track of the score 
    private int livesCounter = 3;   //Keeps Track of the lives left 

    //========== Ball Controls 
    public GameObject ball;
    public Transform spawnPoint;
    public GameObject BallCollector;

    //========== Spike Controls 
    public List<Transform> points;  //Holds all of the points that the spike goes through 
    public float speed = 5;         //The Speed of the spikes movement 
    private int index = 0;          //Which index that spike is moving towards 

    //========== Level Controls 
    public string levelName;

    //===============================================================
    //Base Functions
    //===============================================================

    //Preset the texts 
    private void Start()
    {
        //Present the Text to values of 0
        score.text = "Points: " + scoreCounter;
    }

    // Update is called once per frame
    void Update()
    {
        //Tells it to move from currently standing in point, to given point at the given speed 
        transform.position = Vector3.MoveTowards(transform.position, points[index].position,
                    speed * Time.deltaTime);
        //Rotate to the direction 
        transform.rotation = points[index].rotation;
        //Checks if the enemy reached their goal 
        if (transform.position == points[index].position)
        {
            //If it's the last spot reset 
            if (index == points.Count - 1)
            {
                index = 0;
            }
            //else just go to next point in the list 
            else
            {
                index++;
            }
        }
    }

    //===============================================================
    //Extra Functions 
    //===============================================================

    //Lowers the counter of lives, and updates the text 
    public void SpikeUpdate()
    {
        livesCounter--;
        //Update the text 
        lives.SetText("Lives: " + livesCounter);
        if (livesCounter == 0)
        {
            BackToMainMenu();
        }
    }

    //Increase the score and updates the text 
    public void GoalUpdate()
    {
        scoreCounter++;
        //Update the Text 
        score.SetText("Points: " + scoreCounter);
    }

    //Creates a new ball
    public void SpawnBall()
    {
        //Give position for cookie to spawn at home
        var pos = new Vector3(0, 5, 0);
        //Creates the ball 
        var spawn = Instantiate(ball, pos, Quaternion.identity);
        //Connects to BallCollector
        spawn.transform.SetParent(BallCollector.transform);
    }

    //Sends the game back to the main menu scene 
    public void BackToMainMenu()
    {
        //Send back to the main menu
        SceneManager.LoadScene(levelName);
    }
}

