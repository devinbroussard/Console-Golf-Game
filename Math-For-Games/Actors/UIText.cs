using System;
using System.Collections.Generic;
using System.Text;

namespace Math_For_Games
{
    class UIText : Actor
    {
        Player _player;

        public UIText(Player player)
        {
            _player = player;
        }

        public override void Start()
        {
            base.Start();
            
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            if (!_player.IsGameOver)
            {
                Console.WriteLine($"Current Stroke: {_player.StrokeCounter}");
                return;
            }
            Console.WriteLine($"You won in {_player.StrokeCounter} strokes!");

        }

        public override void End() { }
    }
}
