using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using FiniteSM;
using ADGP125;
using System.Xml.Serialization;

public enum i_STATES
{
    INIT,
    IDLE,
    WALK,
    RUN,
    JUMP,
    KICK,
    EXIT

}

public class FSMTest : MonoBehaviour {

    public InputField CurrentState;

    public ControlPanel Control = ControlPanel.instance;

    public FSM<i_STATES> FSM = new FSM<i_STATES>();

	// Use this for initialization
	void Start () {
        Ctrl IdleCtrl = Update;
        Ctrl WalkCtrl = Update;
        Ctrl RunCtrl = Update;
        Ctrl JumpCtrl = Update;
        Ctrl KickCtrl = Update;
        Ctrl ExitCtrl = Update;
       

        FSM.State(i_STATES.INIT, null);
        FSM.State(i_STATES.IDLE, IdleCtrl);
        FSM.State(i_STATES.WALK, WalkCtrl);
        FSM.State(i_STATES.RUN, RunCtrl);
        FSM.State(i_STATES.JUMP,JumpCtrl);
        FSM.State(i_STATES.KICK, KickCtrl);
        FSM.State(i_STATES.EXIT, ExitCtrl);
        //Switches from Init to Start
        FSM.NewTransition(i_STATES.INIT, i_STATES.IDLE, "d");
        //Switches from Start to Locate
        FSM.NewTransition(i_STATES.IDLE, i_STATES.WALK, "w");
        //Switches from Locate to PTURN
        FSM.NewTransition(i_STATES.WALK, i_STATES.RUN, "q ");
        //Switches from Locate to ETURN
        FSM.NewTransition(i_STATES.RUN, i_STATES.JUMP, "space");
        //Switches from PTURN to FIGHT
        FSM.NewTransition(i_STATES.JUMP, i_STATES.KICK, "a");

        //Returns to start
        FSM.Insert("begin");

        //Displays current state


    }

    void Update()
    {   if (!Input.anyKey)
        {
            CurrentState.text = "IDLE";
        }
        else if (Input.GetKeyDown("d"))
        {
            CurrentState.text = "WALK";
        }
        else if (Input.GetKeyDown("space"))
        {
            CurrentState.text = "JUMP";
        }
        else if (Input.GetKeyDown("q"))
        {
            CurrentState.text = "Kick";
        }
        else if (Input.GetKeyDown("a"))
        {
            CurrentState.text = "RUN";
        }
    
    
    }
	
}
