using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public class Ball : GameObject
    {
        public Ball()
        {
            Size = new Rectangle(12, 12);
        }

        public override void Collision(Collision type)
        {
            switch (type)
            {
                case Models.Collision.Bounds:
                    Velocity = new Vector(Velocity.X, -Velocity.Y);
                    break;
                case Models.Collision.Player:
                    Velocity = new Vector(-Velocity.X, Velocity.Y);
                    var total = Velocity.X * Velocity.X + Velocity.Y * Velocity.Y;
                    Velocity += new Vector(Velocity.X / total, Velocity.Y / total);
                    break;
            }
        }
    }
}
