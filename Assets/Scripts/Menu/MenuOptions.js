/*
#pragma strict

public var isQuit = false;
public var isMain = false;
public var isAbout = false;
public var isMenu = false;

function Start () {
	GetComponent.<Renderer>().material.color = Color.white;
}

function OnMouseEnter () {
	GetComponent.<Renderer>().material.color = Color.red;
}

function OnMouseExit () {
	GetComponent.<Renderer>().material.color = Color.white;
}

function OnMouseUp () {
	if (isQuit == true) {
		Application.Quit();
	}
	else if (isMain == true) {
		Application.LoadLevel("Main");
	}
	else if (isAbout == true) {
		Application.LoadLevel("About");
	}
	else if (isMenu == true) {
		Application.LoadLevel("Menu");
	}
}*/