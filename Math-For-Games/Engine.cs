﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Math_Library;

namespace Golf_Game
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private static Icon[,] _buffer;


        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            //Loops until the application is told to close
            while (!_applicationShouldClose)
            {
                Update();
                Draw();

                Thread.Sleep(15);
            }

            //Called when the application closes
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            //Create new scene
            Scene gameScene = new Scene();
            //Create an add new actors to the scene
            Player player = new Player('.', 1, 3, 10, "Golf Ball", ConsoleColor.White);
            GolfCup golfCup = new GolfCup('P', 30, 4, "Golf Cup", ConsoleColor.Yellow);
            Wall wallOne = new Wall('-', 0, 1, "Wall", ConsoleColor.DarkGray, ConsoleColor.DarkGray, 1);
            Wall wallTwo = new Wall('-', 0, 8, "Wall", ConsoleColor.DarkGray, ConsoleColor.DarkGray, 1);
            Wall wallThree = new Wall('|', 40, 2, "Wall", ConsoleColor.DarkGray, ConsoleColor.DarkGray, 2);
            //Create an add UI Elements to the scene
            UIText strokeText = new UIText(0, 0, "Health", ConsoleColor.Cyan, 30, 10, $"Stroke Count: {player.StrokeCounter}");
            PlayerHud playerHud = new PlayerHud(player, strokeText);

            gameScene.AddUIElement(playerHud);
            gameScene.AddActor(player);
            gameScene.AddActor(golfCup);
            gameScene.AddActor(wallOne);
            gameScene.AddActor(wallTwo);
            gameScene.AddActor(wallThree);

            _currentSceneIndex = AddScene(gameScene);

            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
            _scenes[_currentSceneIndex].UpdateUI();

            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw() 
        {
            //Clear the stuff that was on the screen in the last frame
            _buffer = new Icon[Console.WindowWidth - 1, Console.WindowHeight - 1];

            //Reset the cursor position to the top so the previous screen is drawn over
            Console.SetCursorPosition(0, 0);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();
            _scenes[_currentSceneIndex].DrawUI();

            //Iterate through buffer
            for (int y = 0; y < _buffer.GetLength(1); y++)
            {
                for (int x = 0; x < _buffer.GetLength(0); x++)
                {
                    if (_buffer[x, y].Symbol == '\0')
                    {
                        _buffer[x, y].Symbol = ' ';
                     }

                    //Set console text color to be the color of item at buffer
                    Console.ForegroundColor = _buffer[x, y].ForegroundColor;
                    Console.BackgroundColor = _buffer[x, y].BackGroundColor;
                    //Print the symbol of the item in the buffer
                    Console.Write(_buffer[x, y].Symbol);

                }

                //Skips a line once it reaches the page 
                Console.Write('\n');
            }

            //Sets the cursor visibility to be false
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Called when the application exits
        /// </summary>
        private void End() 
        {
            _scenes[_currentSceneIndex].End();
        }

        /// <summary>
        /// Adds a scene to the engine's scene array
        /// </summary>
        /// <param name="scene">The scene that will be added to the scene array</param>
        /// <returns>The index where the new scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Create a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy all the values from the old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
                tempArray[i] = _scenes[i];

            //Set the last index to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //Return the last index
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetNextKey()
        {
            //If there is no key being pressed...
            if (!Console.KeyAvailable)
                //...return
                return 0;

            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Adds the icon to the buffer to print to the screen in the newxt draw call.
        /// </summary>
        /// <returns>Returns false if the position was out of bounds</returns>
        /// <param name="icon">The icon to draw</param>
        /// <param name="position">The position of where to draw the icon in the buffer</param>
        public static bool Render(Icon icon, Vector2 position)
        {
            //If the position is out of bounds...
            if (position.X < 0 || position.X >= _buffer.GetLength(0) || position.Y < 0 || position.Y >= _buffer.GetLength(1))
                //...return false
                return false;

            //Set the buffer at the index of the given position to be the icon
            _buffer[(int)position.X, (int)position.Y] = icon;
            return true;
        }

        /// <summary>
        /// A function that can be used globally to end the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}
