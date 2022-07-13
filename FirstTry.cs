using Godot;
using System;

public class FirstTry : Control
{
	//private VBoxContainer myVbox = GetNode<VBoxContainer>("ColorRect/VBoxContainer");
	
	private string[]  myArray = {	
	"ButtonA",
	"ButtonB",
	"ButtonC",
	"ButtonD",
	"ButtonE",
	"ButtonF",
	"ButtonG",
	"ButtonH",
	"ButtonJ",
	"ButtonK",
	"ButtonL",
	"ButtonG"};
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AudioStreamPlayer audio = GetNode<AudioStreamPlayer>("Audio");
		VBoxContainer vbox = GetNode<VBoxContainer>("ColorRect/ScrollContainer/VBoxContainer");
		
		foreach (string item in myArray){
			//GD.Print(item);
			
			ColorRect div_holder = new ColorRect();
			Color myColor = new Color (0.5f, 0f, 0.8f, 0.6f);
			div_holder.Call("set_frame_color", myColor);
			Vector2 holderSize = new Vector2(400, 100);
			div_holder.RectMinSize = holderSize;
			
			
			TextureButton button = new TextureButton();
			button.TextureNormal = GD.Load<Texture>("res://ButtonTextures/ButtonBlue.png");
			button.TextureHover = GD.Load<Texture>("res://ButtonTextures/ButtonYellowe.png");
			button.TexturePressed = GD.Load<Texture>("res://ButtonTextures/ButtonRed.png");
			Vector2 Pos = new Vector2(45, 45);
			button.RectPosition = Pos;
			button.Connect("pressed", this,"PlaySound",new Godot.Collections.Array { item , audio});
			
			
			Label text = new Label();
			text.Text = item;
			
			//use call to access methods on nodes 
			text.Call("set_valign", 1);
			text.Call("set_align", 1);
			
			// use snake case to access properties of nodes
			text.AnchorRight = 1;
			text.AnchorBottom = 1;
			
			TextureRect icon = new TextureRect();
			icon.Texture = GD.Load<Texture>("res://ButtonTextures/Icon.png");
			
			Vector2 iconSize = new Vector2(50, 50);
			icon.RectMinSize = iconSize;
			icon.Expand = true;

			button.AddChild(icon);
			button.AddChild(text);
			div_holder.AddChild(button);
			vbox.AddChild(div_holder);
			
		}
	}
	
	public void PlaySound(String items, AudioStreamPlayer audio){
		GD.Print("You are pressing:", items);
		audio.Call("play");
	}
	


}
