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
            asdf
            if (keyPressed == ConsoleKey.1)

            if (keyPressed == ConsoleKey.A)
                moveDirection = new Vector2 { X = -1 };
            if (keyPressed == ConsoleKey.D)
                moveDirection = new Vector2 { X = 1 };
            if (keyPressed == ConsoleKey.W)
                moveDirection = new Vector2 { Y = -1 };
            if (keyPressed == ConsoleKey.S)
                moveDirection = new Vector2 { Y = 1 };


            Velocity = moveDirection * Speed;
            Position += Velocity;
        }

        public override void Draw()
        {
            base.Draw();
            Engine.Render(_clubIcon, Position + new Vector2 { X = -1 });
        }

        public override void OnCollision(Actor actor)
        {
            Engine.CloseApplication();
        }
    }
}
