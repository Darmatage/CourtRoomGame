using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    private int rand_num;
    public Sprite[] Sprite_Pic;
    SpriteRenderer spriteRenderer;

    //private bool inputAllowed = true;

    //UI
    public GameObject scenarioText;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        newCharacter();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
           StartCoroutine(Execute());
        }
        else if (Input.GetKey("left"))
        {
            StartCoroutine(Spare());
        }
    }


    IEnumerator Execute()
    {
        executedText();
        //yield return new WaitForSeconds(5f);
        //slide to right somehow
        for (int i = 0; i < 100; i++) 
        {
            transform.position += new Vector3(30 * Time.deltaTime, 0, 0);
            yield return null;
        }
        //play scream sound
        yield return new WaitForSeconds(2f);
        spriteRenderer.enabled = false;
        newCharacter();
    }



    IEnumerator Spare()
    {
        sparedText();
        yield return new WaitForSeconds(5f);
        //slide to left somehow
        //transform.position += new Vector3(-30 * Time.deltaTime, 0, 0);
        //play Cheer sound
        spriteRenderer.enabled = false;
        newCharacter();
    }

    void newCharacter()
    {
        transform.position = new Vector3(0, 0, 0);

        rand_num = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand_num];
        spriteRenderer.enabled = true;

        //set text to corresponding image
        newScenarioText();
    }

    public void newScenarioText()
    {
        Text textB = scenarioText.GetComponent<Text>();

        if      (rand_num == 0) { textB.text = "Hey, when did it become a crime to wear a ski mask?  It’s fall, and it’s cold! Just because I happened to be walking by the bank during the time of a robbery doesn’t make me a prime suspect.  I swear I saw the real bank robbers run off into the night. I was arrested was because I didn’t have a reason to run."; }
        else if (rand_num == 1) { textB.text = "I uhh– I lost track of my spendings. Why don’t you just give me community service? I’ll be able to pay everyone back eventually, I mean, I’m just forgetful. Why are people always so mad when I take months to venmo them back?" ; }
        else if (rand_num == 3) { textB.text = "Why am I here? Because I hate kittens?"; }
        else if (rand_num == 2) { textB.text = "I see no problem bringing a 700lb beast laptop to class. Although my desk is reinforced with steel beams and I need a power cable stretched all the way across the room, I’m sure this causes no inconvenience for other people. I’m sure everyone loves the colored lights from my RGB Backlit keyboard and the earth shattering hum of my cooling fans. "; }
        else if (rand_num == 4) { textB.text = "Listen. I pay an absurd amount of money each semester to just be here. I don’t see why I should be in trouble for simply stealing a couple dollars of stuff from the cafeteria. I’m basically paying for it anyway."; }
        else                    { textB.text = "Too many sprites! Not enough Scenarios! Ash!!!"; }
    }

    public void executedText()
    {
        Text textB = scenarioText.GetComponent<Text>();
        if      (rand_num == 0) { textB.text = "No! This is all a big misunderstanding. "; }
        else if (rand_num == 1) { textB.text = "There’s no way I can pay anyone back now. "; }
        else if (rand_num == 2) { textB.text = "But I’m allergic to them! "; }
        else if (rand_num == 3) { textB.text = "Destroy my computer for me before I go!"; }
        else if (rand_num == 4) { textB.text = "At least I don’t have to pay for tuition anymore..."; }
        else                    { textB.text = "Too many sprites! Not enough Scenarios! Ash!!!"; }
    }

    public void sparedText()
    {
        Text textB = scenarioText.GetComponent<Text>();
        if (rand_num == 0) { textB.text = "I’m sure you’ll find the actual robbers in no time."; }
        else if (rand_num == 1) { textB.text = "Thank you! I swear I’ll pay everyone back… eventually. "; }
        else if (rand_num == 2) { textB.text = "I see you’re a dog person too huh."; }
        else if (rand_num == 3) { textB.text = "Add me on league of legends"; }
        else if (rand_num == 4) { textB.text = "I’d stay but I have midterms this week"; }
        else { textB.text = "Too many sprites! Not enough Scenarios! Ash!!!"; }
    }

}
