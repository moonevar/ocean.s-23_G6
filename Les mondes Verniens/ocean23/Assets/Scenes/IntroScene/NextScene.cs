using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (InputController.GetKeyDown(InputKey.Enter))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
