using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform player;

    [SerializeField]
    public bool isGameOver = false;
    [SerializeField]
    public GameObject ui_GameOverPage;

    void Awake()
    {
        if(instance == null)
		{
            instance = this;
		}
        else
		{
            Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
	{
        Debug.Log("Game Over");
        StartCoroutine(GameResetTimer());
        isGameOver = true;
        ui_GameOverPage.SetActive(true);

    }

    private IEnumerator GameResetTimer()
    {
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MenuScene");

        //print coroutine ending + scene change
        Debug.Log("Finished Coroutine at timestamp : " + Time.time + " and scene set to menu");
        yield return null;
    }
}
