using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int wealth = 5;
    public int reputation = 0;

    
    public int currWealth {get; private set;}
    public int currReputation {get; private set;}

    
    void Awake()
    {
        currWealth = wealth;
        currReputation = reputation;
    }
    
    void Update (){
        if (Input.GetKeyDown("left"))
        {
            currWealth -= 1;
            currReputation +=1; 
            if (currWealth <= 0)
            {
                Die();
            }
        } else if (Input.GetKeyDown("right"))
        {
            currWealth += 1;
            currReputation -=1; 
            if (currReputation <= 0)
            {
                Die();
            }
        }
    }
    
    public virtual void Die()
    {
        // Go to bad endingm
    }
}
