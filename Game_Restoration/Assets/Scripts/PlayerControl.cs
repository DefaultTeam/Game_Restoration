using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Player Player;
    public GameObject Pausepanel;
    [SerializeField]
    private bool flag = false;
    private bool visible = true;

    private void Start()
    {

        Player = Player == null ? GetComponent<Player>() : Player;
        if (Player == null)
        {
            Debug.LogError("Player not set to controller");
        }
    }

    private void Update()
    {

        if (Player != null)
        {
            if (Input.GetKey(KeyCode.D) && visible)
                Player.MoveRight();
            if (Input.GetKey(KeyCode.A) && visible)
                Player.MoveLeft();
            if (Input.GetKeyDown(KeyCode.Space) && visible)
                Player.Jump();
            if (Input.GetKey(KeyCode.Escape) && !flag)
            {
                //Pausepanel.SetActive(panelvisible);
                Pausepanel.SetActive(!Pausepanel.activeSelf);
                visible = !visible;
                //System.Threading.Thread.Sleep(50);
                flag = true;
            }
            if (!Input.GetKey(KeyCode.Escape) && flag)
                flag = false;
               
            if (Input.GetKeyDown(KeyCode.LeftControl) && visible)
                Player.isStels = true;
            if (Input.GetKeyUp(KeyCode.LeftControl) && visible)
                Player.isStels = false;
            if (Input.GetKeyUp(KeyCode.E) && visible)
                Player.Interact();
        }
    }
}