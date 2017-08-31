using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public enum Controls { UpDown, SX }
    public class Player : GameObject
    {
        Controls controls;
        double speed = 5;

        public Player(Controls controls)
        {
            this.controls = controls;
            Size = new Rectangle(10, 80);
        }

        public override void Update()
        {
            double change = 0;
            if (controls == Controls.UpDown ? Keyboard.Up : Keyboard.S)
            {
                change += speed;
            }
            if (controls == Controls.UpDown ? Keyboard.Down : Keyboard.X)
            {
                change -= speed;
            }

            Velocity = new Vector(0, change);
        }
    }
}
