using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public int BuildIndex;
    // Start is called before the first frame update
    public void Close()
    {
        SceneManager.LoadScene(3);
    }
}
