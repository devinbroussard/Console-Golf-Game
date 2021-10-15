using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;

namespace Golf_Game
{
    class Wall : Actor
    {
        /// <summary>
        /// The wall is type one if it is horizontal, and type two if it is vertical.
        /// </summary>
        private int _type;

        public Wall(char icon, float x, float y, string name, ConsoleColor foregroundColor, ConsoleColor backgroundColor, int type)
          : base(icon, x, y, name, foregroundColor, backgroundColor)
        {
            _type = type;
        }

        public override void Draw()
        {
            if (_type == 1)
                for (int i = 0; i < 41; i++)
                {
                    Engine.Render(Icon, Position + new Vector2 { X = i });
                }
            else if (_type == 2)
                for (int i = 0; i < 6; i++)
                {
                    Engine.Render(Icon, Position + new Vector2 { Y = i });
                }
        }
    }
}
