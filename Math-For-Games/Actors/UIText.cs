using System;
using System.Collections.Generic;
using System.Text;

namespace Math_For_Games
{
    class UIText : Actor
    {
        private static int _strokeCounter;

        public override void Start()
        {
            base.Start();
            _strokeCounter = 0;
        }

        public override void Update()
        {

        }

        public override void Draw()
        {
            
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Current Stroke: {_strokeCounter}");
            
        }

        public override void End() { }

        public static void StrokeCounter() 
        {
            _strokeCounter++;
        }

    }
}
