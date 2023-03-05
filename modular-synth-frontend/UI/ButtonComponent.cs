﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using modular_synth_frontend.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modular_synth_frontend.UI;
internal class ButtonComponent : Component 
{
    public static Texture2D button1; //this doesn't exist yet but will probably be used
    private bool isOn = false;
    private bool isClickingButton;
    //does something go here
    private InputManager input = InputManager.GetInstance();
    public ButtonComponent(Vector2 modulePos, int parentModuleId, Vector2 moduleLocalPos, Texture2D buttonSprite, Color col, string ParameterID, double buttonScale = 1) : base(modulePos, parentModuleId, moduleLocalPos, buttonSprite, col, ParameterID, buttonScale) {
        //does something go here
    }
    public override void UpdatePos(Vector2 modulePos)
    {
        this.modulePos = modulePos;
    }

    public override void addComponentToEtyMgr()
    {
        EntityManager.entities.Add(this);
    }

    public override void sendValToServer()
    {    
        float val = 0;
        if (isOn) {
            val = 1;
        }
        if (val != lastSentVal)
        {
            API.API.setValue(this.parentModuleId, this.parameterID, val);
            lastSentVal = val;
        }
    }
    //does something go here?
    public override void Update()
    {
        this.position = modulePos + moduleLocalPos;
        if (boundingBox.Contains(input.MousePosition()))
        {
            this.isInteracting = true;
            if (input.LeftMouseClickDown())
            {
                isClickingButton = true;
            }
        }
        else
        {
            this.isInteracting = false;
        }
        if (isClickingButton)
        {
            this.isInteracting = true;

            if (input.LeftMouseClickUp())
            {
                this.isInteracting = false;
                //flip button state
                isOn = !isOn;
                isClickingButton = false;
            }
            sendValToServer();
        }
    }
}