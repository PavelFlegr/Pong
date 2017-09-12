using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public class Ball : GameObject
    {
        Random random;

        public Ball()
        {
            Size = new Rectangle(12, 12);
            random = new Random();
        }

        public override void Update()
        {
            var fraction = 500;
            //increase total speed by 1/500
            Velocity += new Vector(Velocity.Unit.X / fraction, Velocity.Unit.Y / fraction);
        }

        public override void Collision(GameObject gameObject)
        {
            switch (gameObject.GetType().Name)
            {
                case nameof(Wall):
                    Velocity = new Vector(Velocity.X, -Velocity.Y);
                    break;
                case nameof(Player):
                case nameof(Computer):
                    int xDir = Velocity.X > 0 ? -1 : 1;
                    int yDir = Velocity.Y > 0 ? 1 : -1;
                    double offset = Math.Abs(Position.Y - gameObject.Position.Y);
                    double speed = Velocity.Size;
                    double yMult = offset / (gameObject.Size.Height / 2) * 0.6;
                    double xMult = 1 - yMult;
                    Vector unitVelocity = new Vector(xMult * xDir, yMult * yDir).Unit;
                    Velocity = new Vector(speed * unitVelocity.X, speed * unitVelocity.Y);
                    break;
            }
        }
    }
}
