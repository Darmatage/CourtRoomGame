using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMaker2000 : MonoBehaviour
{
	
	public GameObject bugToken;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("b")){
                  MakeBugs();
            } 
    }
	
	
	public void MakeBugs(){
		Instantiate(bugToken, this.transform.position, Quaternion.identity);
		
	}
	
	
	
}
