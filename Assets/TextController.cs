using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private int choice = 0;

	private enum States {cell, sheets_0, sheets_1, lock_0, lock_1, mirror, cell_mirror, 
	corridor_0, stairs_0, stairs_1, stairs_2, courtyard, floor, corridor_1, corridor_2,
	corridor_3, closet_door, in_closet
	};
	private States myState;

	public void setChoice (int thisChoice) {
		choice = thisChoice;
	}
	
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {

		if (myState == States.cell) {cell();}
		else if (myState == States.sheets_0) {sheets_0();}
		else if (myState == States.sheets_1) {sheets_1();}
		else if (myState == States.lock_0) {lock_0();}
		else if (myState == States.lock_1) {lock_1();}
		else if (myState == States.mirror) {mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) {corridor_0();}
		else if (myState == States.stairs_0) {stairs_0();}
		else if (myState == States.stairs_1) {stairs_1();}
		else if (myState == States.stairs_2) {stairs_2();}
		else if (myState == States.courtyard) {courtyard();}
		else if (myState == States.floor) {floor();}
		else if (myState == States.corridor_1) {corridor_1();}
		else if (myState == States.corridor_2) {corridor_2();}
		else if (myState == States.corridor_3) {corridor_3();}
		else if (myState == States.closet_door) {closet_door();}
		else if (myState == States.in_closet) {in_closet();}
		choice = 0;
	}

	void in_closet() {
		text.text = "Inside the closet you see a graduation student's uniform that looks about your size! " +
			"Seems like your days of this are over!\n\n" +
				"Press D to Dress up, or R to Return to the hallway";
		if ((Input.GetKeyDown(KeyCode.R))||(choice == 2)) {myState = States.corridor_2;}
		else if ((Input.GetKeyDown(KeyCode.D))||(choice == 1)) {myState = States.corridor_3;}
	}
	void closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
			"Maybe you could find something around to help get it open?\n\n" +
				"Press R to Return to the hallway";
		if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.corridor_0;}
	}
	void corridor_3() {
		text.text = "You're standing back in the hallway, now convincingly dressed as a graduate. " +
			"You strongly consider the run for freedom.\n\n" +
				"Press S to take the Stairs, or U to Undress";
		if ((Input.GetKeyDown(KeyCode.S))||(choice == 1)) {myState = States.courtyard;}
		else if ((Input.GetKeyDown(KeyCode.U))||(choice == 2)) {myState = States.in_closet;}
	}
	void corridor_2() {
		text.text = "Back in the hallway, having declined to dress-up as a senior.\n\n" +
			"Press C to revisit the Closet, and S to go up the stairs";
		if ((Input.GetKeyDown(KeyCode.C))||(choice == 1)) {myState = States.in_closet;}
		else if ((Input.GetKeyDown(KeyCode.S))||(choice == 2)) {myState = States.stairs_2;}
	}
	void corridor_1() {
		text.text = "Still in the hallway. Floor still dirty. Hairclip in hand. " +
			"Now what? You wonder if that lock on the closet would succumb to " +
				"to some lock-picking?\n\n" +
				"P to Pick the lock, and S to climb the stairs";
		if ((Input.GetKeyDown(KeyCode.P))||(choice == 1)) {myState = States.in_closet;}
		else if ((Input.GetKeyDown(KeyCode.S))||(choice == 2)) {myState = States.stairs_1;}
	}
	void floor () {
		text.text = "Rummagaing around on the dirty floor, you find a hairclip.\n\n" +
			"Press R to Return to the standing, or H to take the Hairclip." ;
		if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.corridor_0;}
		else if ((Input.GetKeyDown(KeyCode.H))||(choice == 2)) {myState = States.corridor_1;}
	}
	void courtyard () {
		text.text = "You walk through the courtyard dressed as a graduating student. " +
			"The Principle hands you a diploma as you happily skip past, claiming " +
				"your freedom from school! You heart races with joy as you walk to the bus stop.\n\n" +
				"Press P to Play again." ;
		if ((Input.GetKeyDown(KeyCode.P))||(choice == 1)) {myState = States.cell;}
	}
	void stairs_0 () {
		text.text = "You start walking up the stairs towards the outside light. " +
			"You realise it's not recess time, and you'll be caught in no time. " +
				"You sneak back down the stairs and reconsider.\n\n" +
				"Press R to Return to the hallway." ;
		if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.corridor_0;}
	}
	void stairs_1 () {
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
			"confidence to walk out into a courtyard surrounded by teachers!\n\n" +
				"Press R to Retreat down the stairs" ;
		if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.corridor_1;}
	}
	void stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
			"a hairclip (now badly bent). Even these achievements together don't give " +
				"you the guts to climb up the staris to your detention!\n\n" +
				"Press R to Return to the hallway";
		if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.corridor_2;}
	}
	void cell () {
		text.text = "You are in a new boarding school, and you need to get out fast! There are " +
			"some moldy sheets on the bed, a broken mirror on the wall, and they have " +
				" locked you in from the outside!\n\n" +
				"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if ((Input.GetKeyDown(KeyCode.S))||(choice == 1)) {myState = States.sheets_0;}
		else if ((Input.GetKeyDown(KeyCode.M))||(choice == 2)) {myState = States.mirror;}
		else if ((Input.GetKeyDown(KeyCode.L))||(choice == 3)) {myState = States.lock_0;}
	}
	void mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
			"Press T to Take the mirror, or R to Return to cell" ;
		if ((Input.GetKeyDown(KeyCode.T))||(choice == 1)) {myState = States.cell_mirror;}
		else if ((Input.GetKeyDown(KeyCode.R))||(choice == 2)) {myState = States.cell;}
	}
	void cell_mirror() {
		text.text = "You are still in your room, and you STILL need to escape! There are " +
			"some moldy sheets on the bed, a mark where the mirror was, " +
				"and that evil door is still there, and firmly locked!\n\n" +
				"Press S to view Sheets, or L to view Lock" ;
		if ((Input.GetKeyDown(KeyCode.S))||(choice == 1)) {myState = States.sheets_1;}
		else if ((Input.GetKeyDown(KeyCode.L))||(choice == 2)) {myState = States.lock_1;}
	}
	void sheets_0 () {
		text.text = "You can't believe you sleep in these things. Obviously, it's " +
			"time somebody changed them. The amazing pleasures of prison life " +
				"I guess!\n\n" +
				"Press R to Return to roaming your room" ;
			if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.cell;}
	}
	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
			"any better.\n\n" +
				"Press R to Return to roaming your room" ;
			if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.cell_mirror;}
	}
	void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
			"combination is. You wish you could somehow see where the dirty " +
				"fingerprints were, maybe that would help.\n\n" +
				"Press R to Return to roaming your room" ;
			if ((Input.GetKeyDown(KeyCode.R))||(choice == 1)) {myState = States.cell;}
	}
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
			"so you can see the lock. You can just make out fingerprints around " +
				"the buttons. You press the dirty buttons, and hear a click.\n\n" +
				"Press O to Open, or R to Return to your room" ;
			if ((Input.GetKeyDown(KeyCode.O))||(choice == 1)) {myState = States.corridor_0;}
			else if ((Input.GetKeyDown(KeyCode.R))||(choice == 2)) {myState = States.cell_mirror;}
	}
	void corridor_0() {
		text.text = "You're out of your room, but not out of trouble." +
			"You are in the hallway, there's a closet and some stairs leading to " +
			"the courtyard. There's also various detritus on the floor.\n\n" +
			"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
			if ((Input.GetKeyDown(KeyCode.S))||(choice == 3)) {
			myState = States.stairs_0;
			} else if ((Input.GetKeyDown(KeyCode.F))||(choice == 2)) {
			myState = States.floor;
			} else if ((Input.GetKeyDown(KeyCode.C))||(choice == 1)) {
			myState = States.closet_door;
		}
	}

	void state_cell() {
		text.text = "Your Mom is forcing you to go to boarding School. When you " + 
			"get there, all you see are some moldy sheets on the bed, a dirty mirror on" + 
				" the wall, and they have locked you in from the outside." +
				"You need to get out of this horrible place quick!\n\n" +
				"Press S to view Sheets, M to view Mirror and L to view Lock" ;
			if ((Input.GetKeyDown(KeyCode.S))||(choice == 1)) {myState = States.sheets_0;}
			else if ((Input.GetKeyDown(KeyCode.M))||(choice == 2)) {myState = States.mirror;}
			else if ((Input.GetKeyDown(KeyCode.L))||(choice == 3)) {myState = States.lock_0;}
		}
	}

