﻿using System;
using System.Collections.Generic;
using System.Linq;
using BrewmasterEngine.Framework;
using BrewmasterEngine.Scenes;
using Microsoft.Xna.Framework;
using SampleGame.Menu.Widgets;

namespace SampleGame.Scenes
{
    public class MainMenuScene : Scene
    {
        public MainMenuScene() : base("main")
        {
        }

        protected override void Load(Action done)
        {
            var windowBounds = CurrentGame.Window.ClientBounds;
            var windowSize = new Vector2(windowBounds.Width, windowBounds.Height);

            this.Add(new GradientBackground(Color.Orange, Color.Blue, 2000, 100.0f));
            this.Add(new MenuText("Main Menu", windowSize * new Vector2(0.5f, 0.2f)));
            this.Add(new MenuButton("Start Game", windowSize*new Vector2(0.5f, 0.7f), onButtonUp("game"), onButtonDown()));

            this.Add(new MenuButton("Back to Intro", windowSize * new Vector2(0.5f, 0.8f), onButtonUp("intro"), onButtonDown()));
            this.Add(new MenuButton("Quit", windowSize*new Vector2(0.5f, 0.9f), (button, releasedOn) =>
                {
                    button.Scale = Vector2.One;

                    if (releasedOn)
                        CurrentGame.Exit();
                    
                        
                }, onButtonDown()));

            done();
        }

        private Action<MenuButton> onButtonDown()
        {
            return (button) =>
                {
                    button.Scale = new Vector2(0.9f);
                };
        }

        private Action<MenuButton, bool> onButtonUp(string targetScene)
        {
            return (button, releasedOn) =>
                {
                    button.Scale = Vector2.One;

                    if (releasedOn)
                        CurrentGame.SceneManager.Load(targetScene); 
                };
        }
    }
}