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
    int mostMatch1 = 0;
    int mostMatch2 = 0;
    int mostMatch3 = 0;
    public int[] type = new int[3];
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
        if (GetComponent<Main>().score >= 2)
        {
            GetComponent<Main>().score -= 2;

            float rand;


            for (int i = 0; i < 3; i++)
            {
                rand = Random.Range(0, 100);
                slotArr[i].sprite = (rand < 33 ? gem1 : rand > 33 && rand < 66 ? gem2 : gem3);
                type[i] = (rand < 33 ? 1 : rand > 33 && rand < 66 ? 2 : 3);
            }
            reward();
        }
    }

    public void reward()
    {
         mostMatch1 = 0;
         mostMatch2 = 0;
         mostMatch3 = 0;

        for (int i = 0; i < 3; i++)
        {

            if (type[i] == 1)
            {
                mostMatch1++;
            }
            if (type[i] == 2)
            {
                mostMatch2++;
            }
            if (type[i] == 3)
            {
                mostMatch3++;
            }
        }
        print(mostMatch1 + ",,," + mostMatch2 + ",,," + mostMatch3);
        if (mostMatch1 == mostMatch2 && mostMatch1 == mostMatch3)
        {


            GetComponent<Main>().selectPiece();
        }
        //small jackpot 2x score on match
        if (mostMatch1 == 2)
        {
            GetComponent<Main>().sJ(1);
        }
        if (mostMatch2 == 2)
        {
            GetComponent<Main>().sJ(2);
        }
        if (mostMatch3 == 2)
        {
            GetComponent<Main>().sJ(3);
        }

        //jackpot 4x score on match
        if (mostMatch1 == 3)
        {
            GetComponent<Main>().Jack(1);
        }
        if (mostMatch2 == 3)
        {
            GetComponent<Main>().Jack(2);
        }
        if (mostMatch3 == 3)
        {
            GetComponent<Main>().Jack(3);
        }

    }
    // Update is called once per frame
    void Update()
    {
    }
}
