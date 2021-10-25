using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int wealth_end;
    public int reputation_end;
    public int sprites_displayed;

    // Update is called once per frame
    void Update()
    {
        wealth_end = this.GetComponent<CharacterStats>().wealth;
        reputation_end = this.GetComponent<CharacterStats>().reputation;
        sprites_displayed = GameObject.Find("CharacterSpawner").GetComponent<CharacterSpawner>().total_sprites_displayed;
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if(sprites_displayed >= 15)
        {
            if (wealth_end <= 0)
            {
                SceneManager.LoadScene("Ending1");
            }
            else if (reputation_end < -4)
            {
                SceneManager.LoadScene("Ending2");
            } else 
            {
                SceneManager.LoadScene("Ending3");
            }
        }
    }

    // void FixedUpdate()
    // {
    //     if(sprites_displayed >= 6)
    //     {
    //         if (wealth_end <= 0)
    //         {
    //             SceneManager.LoadScene("Ending1");
    //         }
    //         else if (reputation_end < -4)
    //         {
    //             SceneManager.LoadScene("Ending2");
    //         } else 
    //         {
    //             SceneManager.LoadScene("Ending3");
    //         }
    //     }
    // }
}
