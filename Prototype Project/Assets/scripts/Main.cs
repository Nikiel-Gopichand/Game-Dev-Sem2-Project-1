using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{
    public GameObject target1;
    public GameObject target2;
    public int score;
    public int moves;

    public Text s;
    public Text m;
    public bool mode;
    public bool rewardC;
    public string betBn;
    public GameObject betI;
    //false is swap, true is bet
    // Start is called before the first frame update
    void Start()
    {
        rewardC = false;
        mode = false;
        moves = 10;
    }
    public void swap()
    {
        moves--;
        int temp = target1.GetComponent<grid>().type;
        target1.GetComponent<grid>().type = target2.GetComponent<grid>().type;
        target2.GetComponent<grid>().type = temp;
        target1 = null;
        target2 = null;
    }
    public void swapCheck()
    {

        if ((target1.GetComponent<grid>().up != null ? target2.gameObject.name == target1.GetComponent<grid>().up.gameObject.name : false)
    || (target1.GetComponent<grid>().down != null ? target2.gameObject.name == target1.GetComponent<grid>().down.gameObject.name : false)
    || (target1.GetComponent<grid>().left != null ? target2.gameObject.name == target1.GetComponent<grid>().left.gameObject.name : false)
    || (target1.GetComponent<grid>().right != null ? target2.gameObject.name == target1.GetComponent<grid>().right.gameObject.name : false))
        {
            if (moves > 0)
            {


                swap();
            }
        }
        else
        {
            target1 = null;
            target2 = null;
        }


    }
    public void restart()
    {
        SceneManager.LoadScene(0);
    }
    public void betting()
    {
        mode = true;
    }
    public void target(GameObject t)
    {
        if (mode == false)
        {


            if (target1 == null)
            {
                target1 = t;
            }
            else
            {
                target2 = t;
                swapCheck();
            }
        }
        if (mode == true)
        {
            betBn = t.gameObject.name;
            mode = false;
        }
    }
    public void clearBet()
    {
        betBn = "";
    }
    public void sJ(int t)
    {

        GameObject.Find(betBn).GetComponent<grid>().rewardT = 2;
        GameObject.Find(betBn).GetComponent<grid>().type = t;
        clearBet();

    }

    public void Jack(int t)
    {

        GameObject.Find(betBn).GetComponent<grid>().rewardT = 3;
        GameObject.Find(betBn).GetComponent<grid>().type = t;
        clearBet();

    }
    public void selectPiece()
    {
        rewardC = true;
    }
    public void ot(){
        Application.Quit();

}
    
    public void SP()
    {
        if (rewardC == true)
        {


            if (EventSystem.current.currentSelectedGameObject.name == "1")
            {
                GameObject.Find(betBn).GetComponent<grid>().type = GetComponent<Slots>().type[0];
                rewardC = false;
            }
            if (EventSystem.current.currentSelectedGameObject.name == "2")
            {
                GameObject.Find(betBn).GetComponent<grid>().type = GetComponent<Slots>().type[1];
                rewardC = false;
            }
            if (EventSystem.current.currentSelectedGameObject.name == "3")
            {
                GameObject.Find(betBn).GetComponent<grid>().type = GetComponent<Slots>().type[2];
                rewardC = false;
            }
            clearBet();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (moves <= 0)
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        if (betBn != "")
        {


            betI.GetComponent<Image>().sprite = GameObject.Find(betBn).GetComponent<Image>().sprite;
        }
        s.text = score + "";
        m.text = moves + "";
    }
}
