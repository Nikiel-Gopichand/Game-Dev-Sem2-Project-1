using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class grid : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public GameObject left;
    public GameObject right;
    public int type;
    public int rewardT;
    public Sprite im1;
    public Sprite im2;
    public Sprite im3;
    public Sprite im0;
    // 0 = open, 1= image 1 and so on
    // Start is called before the first frame update
    void Start()
    {
        rewardT = 1;
        string[] rc = this.gameObject.name.Split('x');
        int row = int.Parse(rc[1]);
        int col = int.Parse(rc[0]);
        up = GameObject.Find(col + "x" + (row - 1));
        down = GameObject.Find(col + "x" + (row + 1));
        left = GameObject.Find((col-1) + "x" + (row));
        right = GameObject.Find((col+1) + "x" + (row));

    }
    
    public void onButtonTarget()
    {
        if (type != 0)
        {


            GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>().target(EventSystem.current.currentSelectedGameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().sprite = (type == 0 ? im0 : type == 1 ? im1 : type == 2 ? im2 : im3);

        if (down != null)
        {


            if (down.GetComponent<grid>().type == 0)
            {
                down.GetComponent<grid>().type = type;
                type = 0;
            }
        }
        if (up != null && down != null)
        {


            if (type == up.GetComponent<grid>().type && type == down.GetComponent<grid>().type && type != 0)
            {
                up.GetComponent<grid>().type = type = down.GetComponent<grid>().type = 0;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>().score += 1*rewardT + (1*up.GetComponent<grid>().rewardT+1*down.GetComponent<grid>().rewardT-2);
                rewardT = up.GetComponent<grid>().rewardT = down.GetComponent<grid>().rewardT = 1;

            }
        }
        if (left != null && right != null)
        {


            if (type == left.GetComponent<grid>().type && type == right.GetComponent<grid>().type && type != 0)
            {
                left.GetComponent<grid>().type = type = right.GetComponent<grid>().type = 0;
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>().score += 1*rewardT + (1 * left.GetComponent<grid>().rewardT + 1 * right.GetComponent<grid>().rewardT - 2);
                rewardT = left.GetComponent<grid>().rewardT = right.GetComponent<grid>().rewardT = 1;

            }
        }
        
    }
}
