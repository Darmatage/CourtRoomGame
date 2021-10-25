using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpawner : MonoBehaviour
{
    private int rand_num;
    public Sprite[] Sprite_Pic;
    SpriteRenderer spriteRenderer;

    public int total_sprites_displayed = 0;

    private bool inputAllowed = true;

    //dialogue object
    public Dialogue dialogue;

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
        if (Input.GetKey("escape")){
            Application.Quit();
        } else if(inputAllowed == true){
            if (Input.GetKey("right"))
            {
               StartCoroutine(Execute());
               inputAllowed = false;
            }
            else if (Input.GetKey("left"))
            {
                StartCoroutine(Spare());
                inputAllowed = false;
            }
        }
    }


    IEnumerator Execute()
    {
        executedText();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 900; i++)
        {
            transform.position += new Vector3(10 * Time.deltaTime, 0, 0);
            yield return null;
        }
        //play scream sound
        yield return new WaitForSeconds(.5f);
        spriteRenderer.enabled = false;
        newCharacter();

        inputAllowed = true;
    }



    IEnumerator Spare()
    {
        sparedText();
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < 900; i++)
        {
            transform.position += new Vector3(-10 * Time.deltaTime, 0, 0);
            yield return null;
        }
        //play scream sound
        yield return new WaitForSeconds(.5f);
        spriteRenderer.enabled = false;
        newCharacter();

        inputAllowed = true;
    }

    void newCharacter()
    {
        transform.position = new Vector3(0, 0.65f, 0);

        rand_num = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand_num];
        spriteRenderer.enabled = true;
        total_sprites_displayed += 1;
        //set text to corresponding image


        newScenarioText();
    }

    public void TriggerDialogue (string[] sentences){


        dialogue.scenarioSentences = sentences;

        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    public void newScenarioText()
    {
        //Text textB = scenarioText.GetComponent<Text>();

        string[] sentences;


        if      (rand_num == 0) { sentences = new string [] {"Hey, when did it become a crime to wear a ski mask?  It's fall, and it's cold!", "Just because I happened to be walking by the bank during the time of a robbery doesn't make me a prime suspect.", "I swear I saw the real bank robbers run off into the night. I was arrested was because I didn't have a reason to run."}; }
        else if (rand_num == 1) { sentences = new string [] {"I uhh, I lost track of my spendings. Why don't you just give me community service?", "I'll be able to pay everyone back eventually, I mean, I'm just forgetful.", "Why are people always so mad when I take months to venmo them back?"}; }
        else if (rand_num == 2) { sentences = new string [] {"Why am I here? Because I hate kittens?"}; }
        else if (rand_num == 3) { sentences = new string [] {"I see no problem bringing a 700lb beast laptop to class.", "Although my desk is reinforced with steel beams and I need a power cable stretched all the way across the room, I'm sure this causes no inconvenience for other people.", "I'm sure everyone loves the colored lights from my RGB Backlit keyboard and the earth shattering hum of my cooling fans."}; }
        else if (rand_num == 4) { sentences = new string [] {"Listen. I pay an absurd amount of money each semester to just be here.", "I don't see why I should be in trouble for simply stealing a couple dollars of stuff from the cafeteria.", "I'm basically paying for it anyway."}; }
        else if (rand_num == 5) { sentences = new string [] {"I am a very busy person. I am triple majoring in IR, econ and CS.", "I have to network on linkedin and study for midterms. And honestly, leaving people on delivered is BETTER than leaving people on read.", "I could easily just open your message and say something like I'll get back to you but I am legitimately so busy I don't even have time for that.", "Now please let me leave, I need to wake up early for a club meeting tomorrow."}; }
        else if (rand_num == 6) { sentences = new string [] {"Are you sure those dishes are mine? It's been so long I don't remember what is mine anymore.", "Can't you just be nice this one time and wash it for me?", "I mean, I don't really want to touch mold and it'll be easier for everyone anyway, especially if you need to use it."}; }
        else if (rand_num == 7) { sentences = new string [] {"I will always be there for you when you need help. I'm just busy right now, ok?", "Alsoooo what are you plans for thanksgiving huh, I heard your family lives in New York.", "Do you mind if I crash at your place haha. Oh and also, could you send me your homework?", "I swear I'll send you mine as well, after I've had time to look at yours."}; }
        else if (rand_num == 8) { sentences = new string [] {"Ok who exactly is this a crime against?", "It's not like workers at the t-station lose pay because I walk through with people who are paying.", "Transportation is already ridiculously overpriced and yeah sure I can afford it, but I'm literally only travelling 3 stops!", "Executing me is honestly more of a robbery because I won't be able to grow up and end up paying taxes that overshoot the price of me jumping turnstiles anyway."}; }
        else if (rand_num == 9) { sentences = new string [] {"You know what's worse than getting COVID? Missing a class.", "Can you imagine what I'll have to do if I miss a class?", "I'll have to watch the lecture remotely and email the professor about attendance!", "I know I don't have COVID. I mean, I probably just have a cold and I keep my mask on anyway.", "Sure the classroom is kinda packed and everyone around me terrified, but I just KNOW I don't have COVID!",
                                                             "It's other people's fault if I scare them enough to distract them from class because they're just discriminating against me for coughing."}; }
        else                    { sentences = new string [] {"If you're here our game broke a little. Just kill or spare the guy. Your call!"}; }

        TriggerDialogue(sentences);
    }

    public void executedText()
    {
        //Text textB = scenarioText.GetComponent<Text>();
        string[] sentences;


        if      (rand_num == 0) { sentences = new string [] {"No! This is all a big misunderstanding."}; }
        else if (rand_num == 1) { sentences = new string [] {"There's no way I can pay anyone back now. "}; }
        else if (rand_num == 2) { sentences = new string [] {"But I'm allergic to them!"}; }
        else if (rand_num == 3) { sentences = new string [] {"Destroy my computer for me before I go!"}; }
        else if (rand_num == 4) { sentences = new string [] {"At least I don't have to pay for tuition anymore..."}; }
        else if (rand_num == 5) { sentences = new string [] {"left on delivered forever"}; }
        else if (rand_num == 6) { sentences = new string [] {"should've went on the infinite meal plan"}; }
        else if (rand_num == 7) { sentences = new string [] {"What but I thought we were friends..."}; }
        else if (rand_num == 8) { sentences = new string [] {"Good luck trying to catch everyone who does this"}; }
        else if (rand_num == 9) { sentences = new string [] {"It's not my fault people are cowards!"}; }
        else                    { sentences = new string [] {"Too many sprites! Not enough Scenarios! Ash!!!"}; }

        TriggerDialogue(sentences);
    }

    public void sparedText()
    {
        //Text textB = scenarioText.GetComponent<Text>();
        string[] sentences;

        if (rand_num == 0) { sentences = new string [] {"I'm sure you'll find the actual robbers in no time."}; }
        else if (rand_num == 1) { sentences = new string [] {"Thank you! I swear I'll pay everyone back eventually. "}; }
        else if (rand_num == 2) { sentences = new string [] {"I see you're a dog person too huh."}; }
        else if (rand_num == 3) { sentences = new string [] {"Add me on league of legends"}; }
        else if (rand_num == 4) { sentences = new string [] {"I'd stay but I have midterms this week"}; }
        else if (rand_num == 5) { sentences = new string [] {"I swear I'll reply! Eventually"}; }
        else if (rand_num == 6) { sentences = new string [] {"Lemme finish something real quick before I do the dishes"}; }
        else if (rand_num == 7) { sentences = new string [] {"I knew I could count on you!"}; }
        else if (rand_num == 8) { sentences = new string [] {"Probably the cheaper option"}; }
        else if (rand_num == 9) { sentences = new string [] {"*coughs violently*"}; }
        else { sentences = new string [] {"If you're here. It was probably Finn who messed up. Remember that."}; }

        TriggerDialogue(sentences);
    }

}
