using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool isOpen = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == false)
            {
                Time.timeScale = 0;
                isOpen = true;
                SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
            }
            else
            {
                Time.timeScale = 1;
                isOpen = false;
                SceneManager.UnloadSceneAsync("MainMenu");
            }
        }

    }
    void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
