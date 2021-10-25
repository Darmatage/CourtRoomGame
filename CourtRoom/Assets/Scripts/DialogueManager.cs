using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;

    private Queue<string> sentences;

    public Animator animator;

    public bool emptyStack;

    void Start()
    {
        sentences = new Queue<string>();
        emptyStack = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            emptyStack = false;
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        FindObjectOfType<CharacterSpawner>().sentencesDone(false);

        sentences.Clear();

        foreach(string sentence in dialogue.scenarioSentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            emptyStack = true;
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        FindObjectOfType<CharacterSpawner>().sentencesDone(true);
    }
}
