using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TotallyNotCheatScript : MonoBehaviour
{
    [SerializeField] string CheatCode;
    [SerializeField] string CurrentWriting;
    string Key;
    [SerializeField] playerMovement PlayerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWriting = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Key = Input.inputString;
            if(Key == "x")
            {
                CurrentWriting = "";
            }
            else
            {
                CurrentWriting = CurrentWriting + Key;
                if(CurrentWriting == CheatCode){
                    print("SNYYYYYYYYYYYYYYYYYYYYYYD");
                    PlayerMovementScript.moveSpeed *= 2;
                    CurrentWriting = "";

                }
            }
                
            
        }
    }
}
