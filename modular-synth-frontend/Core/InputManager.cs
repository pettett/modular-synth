﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace modular_synth_frontend.Core;

public class InputManager
{
	private static InputManager instance = new(); //singleton pattern fr fr
	MouseState oldState, newState;
	KeyboardState oldKeyState, newKeyState;


	public static bool IsMouseOverComponent { get; set; }

	private InputManager() { }

	public static InputManager GetInstance()
	{
		return instance;
	}

	public void Update()
	{
		oldState = newState;
		oldKeyState = newKeyState;
		newState = Mouse.GetState();
		newKeyState = Keyboard.GetState();

		if (IsMouseOverComponent)
			Mouse.SetCursor(MouseCursor.Hand);
		else
			Mouse.SetCursor(MouseCursor.Arrow);

		IsMouseOverComponent = false;
	}

	public bool KeyPressed(Keys key)
	{
		if (newKeyState.IsKeyDown(key))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool KeyDown(Keys key)
	{
		if (newKeyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool KeyUp(Keys key)
	{
		if (newKeyState.IsKeyUp(key) && oldKeyState.IsKeyDown(key))
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool LeftMousePressed()
	{
		if (newState.LeftButton == ButtonState.Pressed)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool LeftMouseClickDown()
	{
		if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool LeftMouseClickUp()
	{
		if (newState.LeftButton == ButtonState.Released && oldState.LeftButton == ButtonState.Pressed)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RightMousePressed()
	{
		if (newState.RightButton == ButtonState.Pressed)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RightMouseClickDown()
	{
		if (newState.RightButton == ButtonState.Pressed && oldState.RightButton == ButtonState.Released)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool RightMouseClickUp()
	{
		if (newState.RightButton == ButtonState.Released && oldState.RightButton == ButtonState.Pressed)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public bool MouseWheelUp()
	{
		if (newState.ScrollWheelValue > oldState.ScrollWheelValue)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public bool MouseWheelDown()
	{
		if (newState.ScrollWheelValue < oldState.ScrollWheelValue)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public Point MousePosition()
	{
		return newState.Position;
	}

	public Vector2 MousePosVector()
	{
		return new Vector2(newState.Position.X, newState.Position.Y);
	}
}

