using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public Image result1;
    public Image result2;
    public Image result3;

    public Sprite gem1;
    public Sprite gem2;
    public Sprite gem3;
    Image[] slotArr = new Image[3];
    // Start is called before the first frame update
    void Start()
    {
        
        slotArr[0] = result1;
        slotArr[1] = result2;
        slotArr[2] = result3;

    }
    public void onRoll()
    {
        float rand;


        for (int i = 0; i < 3; i++)
        {
            rand = Random.Range(0, 100);
            slotArr[i].sprite = (rand < 33 ? gem1 : rand > 33 && rand < 66 ? gem2 : gem3);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
