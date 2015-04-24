using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	public bool wire = false;
	
	private enum States {cell, cell_0, cell_1, mirror, sheets_0, lock_0, cell_mirror, take_wire,
	 					sheets_1, lock_1, freedom};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		
		// Control the current state of the story
		switch (myState)
		{
			case States.cell:{
				state_cell();
				break;
			}
			case States.cell_0:{
				state_cell_0();
				break;
			}
			case States.sheets_0:{
				state_sheets_0();
				break;
			}
			case States.lock_0:{
				state_lock_0();
				break;
			}
			case States.mirror:{
				state_mirror();
				break;
			}
			case States.cell_mirror:{
				state_cell_mirror();
				break;
			}
			case States.take_wire:{
				state_take_wire();
				break;
			}
			case States.cell_1:{
				state_cell_1();
				break;
			}
			case States.sheets_1:{
				state_sheets_1();
				break;
			}
			case States.lock_1:{
				state_lock_1();
				break;
			}
			case States.freedom:{
				state_freedom();
				break;
			}
		}
	}
	// Starting state
	void state_cell(){
	// Input.GetKeyDown example:
		//if (Input.GetKeyDown ("space")){
		//alternatively
		//if (Input.GetKeyDown (KeyCode.Space)){
		text.text =	"You are in some sort of <color=red>prison</color> cell. You've been here for weeks, " +
					"may be months.\n" + 
					"You want to <color=green>escape</color>.\n" +
					"There are some dirty sheets on the bed, there's a mirror on the wall, and the door " +
					"is locked from the outside.\n\n " +
					"Press <color=orange>S</color> to view Sheets, <color=orange>M</color> to view Mirror " + 
					"or <color=orange>L</color> to view Lock";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown(KeyCode.M)){
			myState = States.mirror;
		}
		if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_0;
		}
	}
	// Cell state without wire
	void state_cell_0(){
		text.text =	"You want to <color=green>escape</color>.\n" +
					"There are some dirty sheets on the bed, there's a mirror on the wall, and the door " +
					"is locked from the outside.\n\n " +
					"Press <color=orange>S</color> to view Sheets, <color=orange>M</color> to view Mirror " + 
					"or <color=orange>L</color> to view Lock";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_0;
		}
		if (Input.GetKeyDown(KeyCode.M)){
			if (wire == false){
				myState = States.mirror;
			} else {
				myState = States.cell_mirror;
			}
			
		}
		if (Input.GetKeyDown(KeyCode.L)){
			if (wire == false){
				myState = States.lock_0;
			} else {
				myState = States.lock_1;
			}
		}
	}
	// Sheets state without wire
	void state_sheets_0(){
		text.text =	"The sheets look as though they've never been washed. You wonder how many other people " +
					"have been held prisoner here. You have no use for these dirty sheets. You're definately " + 
					"not climbing out any windows at this stage.\n" + 
					"You want to <color=green>escape</color>.\n\n" +
					"Press <color=orange>R</color> to Return";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
	}
	// Lock state without wire
	void state_lock_0(){
		text.text = "You look at the door lock. "+
					"Looking at the lock you remembered trying to pick a lock in highschool, you remember " +
					"the theory. You definately have the time to try...\n" +
					"...but certainly not without any tools.\n\n " +
					"Press <color=orange>R</color> to Return";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
	}
	// Mirror state without wire
	void state_mirror(){
		text.text = "Looking at the mirror reminds you of how long you've been imprisoned. Your face is dirty" +
					" and your hair has grown. Has many weeks has it been again??\n" +
					"You want to <color=green>escape</color>.\n\n" +
					"Focusing back onto your goal you stop looking into the mirror and start looking at it." + 
					"Suddenly you notice that the mirror is mounted with screws, and that one screw has a " +
					"wire wrapped around it.\n\n" +
					"Press <color=orange>R</color> to Return or " +
					"press <color=orange>T</color> to Take the wire"; 
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		} else if (Input.GetKeyDown(KeyCode.T)){
			myState = States.take_wire;
		}
	}
	// Taking the wire
	void state_take_wire(){
		text.text = "You unwrap the wire. next you try to loosen the screw, but it's too tight. May be even " +
					"rusted in.\n\n" +
					"Press <color=orange>R</color> to Return, <color=orange>S</color> to view Sheets " + 
					"or <color=orange>L</color> to view Lock";
		// set flag to show that the user has thw wire item
		wire = true;
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_1;
		} else if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_1;
		}else if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1;
		}
	}
	// Mirror state with wire
	void state_cell_mirror(){
		text.text = "Looking at the mirror reminds you of how long you've been imprisoned. Your face is dirty" +
					" and your hair has grown. Has many weeks has it been again??\n" +
					"You want to <color=green>escape</color>.\n\n" +
					"Press <color=orange>R</color> to Return";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		}
	}
	// Sheets state with wire
	void state_sheets_1(){
		text.text = "Looking at the sheets you think that you cannot spend one more night in this cruel cell.\n" +
					"You want to <color=green>escape</color>.\n\n" +
					"Press <color=orange>R</color> to Return to viewing your cell";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell;
		}
	}
	// Cell state with wire
	void state_cell_1(){
		text.text =	"You want to <color=green>escape</color>.\n" +
					"There are some dirty sheets on the bed, there's a mirror on the wall, and the door " +
					"is locked from the outside.\n" +
					"You think about the wire you found by the mirror.\n\n" + 
					"Press<color=orange>S</color> to view Sheets, <color=orange>M</color> to view Mirror " + 
					"or <color=orange>L</color> to view Lock";
		if (Input.GetKeyDown(KeyCode.S)){
			myState = States.sheets_1;
		}
		if (Input.GetKeyDown(KeyCode.M)){
			if (wire == false){
				myState = States.mirror;
			} else {
				myState = States.cell_mirror;
			}
		}
		if (Input.GetKeyDown(KeyCode.L)){
			myState = States.lock_1;
		}
	}
	// Lock state with wire
	void state_lock_1(){
		text.text = "You look at the door lock. "+
					"Looking at the lock you remembered trying to pick a lock in highschool, you remember " +
					"the theory.\n" +
					"...you bend the wire into shape.\n\n " +
					"Press <color=orange>R</color> to Return or <color=orange>P</color> to Pick the lock";
		if (Input.GetKeyDown(KeyCode.R)){
			myState = States.cell_0;
		} else if (Input.GetKeyDown(KeyCode.P)){
			myState = States.freedom;
		}
	}
	// Freedom State - door unlocked
	void state_freedom(){
		text.text = "You fiddle around with the wire for probably over an hour. Suddenly you hear the sweet " +
					"sound of a latch clicking.\n" +
					"You slowly open the door, almost not believing your escape could be upon you.\n" + 
					"Then you leave the room which has been your cell and towards an exit....\n\n" +
					"<color=green>Freedom!?!</color>" +
					"\n\n\nPress <color=yellow>P</color> to Play again";
		if (Input.GetKeyDown(KeyCode.P)){
			myState = States.cell;
		}
	}

}
