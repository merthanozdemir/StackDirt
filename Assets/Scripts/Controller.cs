using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public static Controller instance;
    public Spawner box_spawner;
    public Dirt currentBox;
    public CameraGoUp cameraFollow;
    private int moveCount;


    void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
    void Start()
    {
        box_spawner.Dirt_Spawner();
    }

    // Update is called once per frame
    void Update()
    {
        inputDetect();
    }
    void inputDetect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentBox.dropDirt();

        }
    }
    public void spawnNew() {
        Invoke("newbox", 0.1f);
    }
    public void newbox() {
        box_spawner.Dirt_Spawner();
    }

    public void moveCamera() {
        moveCount++;
        Debug.Log(moveCount);
        if (moveCount == 4)
        {
            moveCount = 0;
            cameraFollow.targetPoss.y += 2f;
           // Debug.Log("yükseklik: " + cameraFollow.targetPoss.y);
        }
    }
    public void RestartGame() {
        Debug.Log("yeniden baþlat");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
