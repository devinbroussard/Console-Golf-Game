using System;
using System.Collections.Generic;
using System.Text;

namespace Golf_Game
{
    class PlayerHud : Actor
    {
        private Player _player;
        private UIText _strokes;

        public PlayerHud(Player player, UIText strokes)
        {
            _player = player;
            _strokes = strokes;
        }

        public override void Start()
        {
            base.Start();
            _strokes.Start();
        }

        public override void Update()
        {
            _strokes.Text = $"Current Stroke: {_player.StrokeCounter}";
        }

        public override void Draw()
        {
            _strokes.Draw();
        }
    }
}
