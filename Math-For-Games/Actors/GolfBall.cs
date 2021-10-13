using System;
using System.Collections.Generic;
using System.Text;
using Math_Library;

namespace Math_For_Games
{
    class GolfBall : Actor
    {
        private float _speed;
        private Vector2 _velocity;
        private Icon _clubIcon;

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public Vector2 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public GolfBall(char icon, float x, float y, float speed, string name = "actor", ConsoleColor color = ConsoleColor.White)
            : base(icon, x, y, name, color)
        {
            _speed = speed;
            _clubIcon = new Icon { Color = ConsoleColor.Blue, Symbol = 'L' };
        }

        public override void Update()
        {
            Vector2 moveDirection = new Vector2();

            ConsoleKey keyPressed = Engine.GetNextKey();

            if (keyPressed == ConsoleKey.D1) 
            {
                _clubIcon.Color = ConsoleColor.Blue;
                Speed = 10;
            }
            if (keyPressed == ConsoleKey.D2)
            {
                _clubIcon.Color = ConsoleColor.DarkGreen;
                Speed = 5;
            }
            if (keyPressed == ConsoleKey.D3)
            {
                _clubIcon.Color = ConsoleColor.Magenta;
                Speed = 1;

            }

            if (keyPressed == ConsoleKey.A)
            {
                moveDirection = new Vector2 { X = -1 };
                UIText.StrokeCounter();
            }
            if (keyPressed == ConsoleKey.D)
            {
                moveDirection = new Vector2 { X = 1 };
                UIText.StrokeCounter();
            }
            if (keyPressed == ConsoleKey.W)
            {
                moveDirection = new Vector2 { Y = -1 };
                UIText.StrokeCounter();
            }
            if (keyPressed == ConsoleKey.S)
            {
                moveDirection = new Vector2 { Y = 1 };
                UIText.StrokeCounter();
            }

            Velocity = moveDirection * Speed;
            Position += Velocity;

            if (Position.Y < 2)
                Position = new Vector2 { X = Position.X, Y = 2 };
            if (Position.Y > 7)
                Position = new Vector2 { X = Position.X, Y = 7 };
            if (Position.X > 39)
                Position = new Vector2 { X = 39, Y = Position.Y };


        }

        public override void Draw()
        {
            base.Draw();
            Engine.Render(_clubIcon, Position + new Vector2 { X = -1 });
        }

        public override void OnCollision(Actor actor)
        {
            if (actor is GolfCup)
            {
                Engine.CloseApplication();
            }
        }
    }
}
