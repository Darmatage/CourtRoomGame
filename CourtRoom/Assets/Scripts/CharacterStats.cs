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

        } 
        else if (Input.GetKeyDown("right"))
        {
            currWealth += 1;
            currReputation -=1; 
        }
    }
    
}
