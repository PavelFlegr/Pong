using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.Game.Models
{
    public struct Bounds
    {
        public double Top;
        public double Bottom;
        public double Left;
        public double Right;

        public Bounds(Vector position, Rectangle size)
        {
            Top = position.Y + size.Height / 2;
            Bottom = position.Y - size.Height / 2;
            Left = position.X - size.Width / 2;
            Right = position.X + size.Width / 2;
        }
    }
}
