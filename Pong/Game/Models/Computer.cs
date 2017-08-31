using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public class Computer : GameObject
    {
        double speed = 5;
        public Computer()
        {
            Size = new Rectangle(10, 80);
        }

        public override void Update()
        {
            Velocity = new Vector(0, 0);
            if (View.currentBall.Bounds.Top > Bounds.Top)
            {
                Velocity = new Vector(0, speed);
            }
            else if (View.currentBall.Bounds.Bottom < Bounds.Bottom)
            {
                Velocity = new Vector(0, -speed);
            }
        }
    }
}
